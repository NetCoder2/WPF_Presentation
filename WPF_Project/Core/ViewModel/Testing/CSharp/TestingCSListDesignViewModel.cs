using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Core
{
    public class TestingCSListDesignViewModel : PagedItemsDataVieweModel<TestAnswer>
    {
        /// <summary>
        /// Stores ids of given answers
        /// </summary>
        public List<int> GivenAnswers
        {
            get; set;
        }

        TestQuestion currentQuestion = new TestQuestion();
        public TestQuestion CurrentQuestion
        {
            get { return currentQuestion; }
        }

        public override void GetItems(int pageSize, int pageIndex)
        {
            currentQuestion = new TestQuestion();
            Items = new AdvancedObservableCollection<TestAnswer>();


            switch (pageIndex)
            {
                case 1:
                    {

                        var correctAnswers =
                            QuestionsGenerator.GenerateFirstQuestion(null);
                        var answerId = wrongAnswerId(PageIndex, correctAnswers);

                        currentQuestion = QuestionsGenerator.GenerateFirstQuestion(answerId);


                        break;
                    }
                case 2:
                    {
                        var correctAnswers =
                            QuestionsGenerator.GenerateSecondQuestion(null);
                        var answerId = wrongAnswerId(PageIndex, correctAnswers);


                        currentQuestion = QuestionsGenerator.GenerateSecondQuestion(answerId);
                        break;
                    }
                case 3:
                    {
                        var correctAnswers =
                            QuestionsGenerator.GenerateThirdQuestion(null);
                        var answerId = wrongAnswerId(PageIndex, correctAnswers);


                        currentQuestion = QuestionsGenerator.GenerateThirdQuestion(answerId);
                        break;
                    }
            }

            Items.AddRange(currentQuestion.Answers);

        }

        /// <summary>
        /// Function to get given uncorrect answer's id
        /// </summary>
        /// <param name="pageIndex">current page index</param>
        /// <param name="question">current question</param>
        /// <returns>Uncorrect answer id, if it was found</returns>
        private int? wrongAnswerId(int pageIndex, TestQuestion question)
        {
            int? wrongAnswerId = null;
            // if all questions have been answered
            if (GivenAnswers != null && GivenAnswers.Count == PageCount)
            {
                var givenAnswerId = GivenAnswers[pageIndex - 1];

                //MessageBox.Show(givenAnswerId.ToString());
                var answ = question.Answers;
                var correctId = answ.Where(a => a.IsCorrectAnswer);
                //MessageBox.Show(correctId.First().Id.ToString());
                if (givenAnswerId != correctId.First().Id)
                {
                    wrongAnswerId = givenAnswerId;
                }
            }

            return wrongAnswerId;
        }
    }

}
