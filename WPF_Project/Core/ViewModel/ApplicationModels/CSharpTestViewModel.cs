using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core
{
    /// <summary>
    /// The view model to perform C# test
    /// </summary>
    public class CSharpTestViewModel  : WindowModel
    {
        private bool isFinishedTest = false;


        public string QuestionText
        {
            get; set;

        }

        public List<TestQuestion> Questions { get; set; } = new List<TestQuestion>();

        /// <summary>
        /// Shows/Hides Pager buttons
        /// </summary>
        public bool IsPagerButtonsVisible
        {
            get;
            set;
        }

        /// <summary>
        /// Enables/Disables next question button
        /// </summary>
        public bool IsNextQuestionEnabled  { get; set; } = true;


        /// <summary>
        /// Enables/Disables pager
        /// </summary>
        public bool IsPagerEnabled
        {
            get;
            set;
        }



        /// <summary>
        /// Data context with list of answers
        /// </summary>
        public TestingCSListDesignViewModel TestSelectionDataContext { get; set; }

        /// <summary>
        /// The command to go to next question
        /// </summary>
        private ICommand nextQuestionCommand;
        public ICommand NextQuestionCommand
        {
            get
            {
                return nextQuestionCommand ??
                  (nextQuestionCommand = new RelayCommand(param =>
                  {
                      PerformTest();
                  }));
            }
        }


        /// <summary>
        /// The command during page changing
        /// </summary>
        private ICommand pageChangedCommand;
        public ICommand PageChangedCommand
        {
            get
            {
                return pageChangedCommand ??
                  (pageChangedCommand = new RelayCommand(param =>
                  {
                      PerformAnswer();
                  }));
            }
        }


        /// <summary>
        /// Gets the current question depending on the page index
        /// </summary>
        private void PerformTest()
        {
            if (TestSelectionDataContext.SelectedItemId == null)
            {
                ShowInformationWindow("Please, select at least one answer", "Answer selection");
            }

            if (TestSelectionDataContext.SelectedItemId != null && !isFinishedTest)
            {
                TestSelectionDataContext.GivenAnswers.Add(TestSelectionDataContext.SelectedItemId.Value);
                TestSelectionDataContext.SelectedItem = null;
                if (TestSelectionDataContext.PageIndex < TestSelectionDataContext.PageCount)
                {
                    TestSelectionDataContext.PageIndex++;
                    GetQuestionText();
                }
                // the test has been finished
                else
                {
                    IsPagerButtonsVisible = true;
                    TestSelectionDataContext.PageIndex = 1;
                    isFinishedTest = true;

                    TestSelectionDataContext.CalculateAnswersCount();
                    ShowInformationWindow(string.Format("Correct answers: {0}, wrong answers: {1}",
                        TestSelectionDataContext.CorrectCount, TestSelectionDataContext.WrongCount), 
                        "All answers review");

                    IsPagerEnabled = isFinishedTest;
                    IsNextQuestionEnabled = false;

                    PerformAnswer();
                }
            }
        }

        private void PerformAnswer()
        {
            if (isFinishedTest)
            {
                var correctItem = TestSelectionDataContext.Items.Where(i => i.IsCorrectAnswer);
                TestSelectionDataContext.SelectedItemId = correctItem.First().Id;
                GetQuestionText();
            }
        }

        /// <summary>
        /// Gets the current queastion's text
        /// </summary>
        private void GetQuestionText()
        {
            // gets question text
            QuestionText = TestSelectionDataContext.CurrentQuestion.QuestionText;
        }


        public CSharpTestViewModel()
        {
            TestSelectionDataContext = new TestingCSListDesignViewModel();
            TestSelectionDataContext.PageCount = TestSelectionDataContext.QuestionCount;
            TestSelectionDataContext.GivenAnswers = new List<int>();
            GetQuestionText();
        }
    }
}
