using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core
{
    public class TestingSelectionViewModel : BaseViewModel
    {

        private bool isFinishedTest = false;


        public string QuestionText
        {
            get; set;

        }

        /// <summary>
        /// Shows/Hides Pager buttons
        /// </summary>
        public bool IsPagerButtonsVisible
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
            if (TestSelectionDataContext.SelectedItemId != null && !isFinishedTest)
            {
                TestSelectionDataContext.GivenAnswers.Add(TestSelectionDataContext.SelectedItemId.Value);
                TestSelectionDataContext.SelectedItem = null;
                if (TestSelectionDataContext.PageIndex < TestSelectionDataContext.PageCount)
                {
                    TestSelectionDataContext.PageIndex++;
                    GetQuestionText();
                }
                else
                {
                    IsPagerButtonsVisible = true;
                    TestSelectionDataContext.PageIndex = 1;
                    isFinishedTest = true;

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
            //TestSelectionDataContext.CurrentQuestion.QuestionText;
            // gets question text
            //QuestionText = questions.Questions[TestSelectionDataContext.PageIndex-1].QuestionText;
            QuestionText = TestSelectionDataContext.CurrentQuestion.QuestionText;
        }


        public TestingSelectionViewModel()
        {
            TestSelectionDataContext = new TestingCSListDesignViewModel();
            TestSelectionDataContext.PageCount = 3;
            TestSelectionDataContext.GivenAnswers = new List<int>();
            GetQuestionText();
        }
    }
}
