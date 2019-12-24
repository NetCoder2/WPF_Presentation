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

        public List<TestQuestion> Questions { get; set; } = new List<TestQuestion>();

        /// <summary>
        /// Count of questions
        /// </summary>
        public int QuestionCount
        { private set;  get; } = 6;

        /// <summary>
        /// Count of correct answers
        /// </summary>
        public int CorrectCount
        { private set; get; }


        /// <summary>
        /// Count of wrong answers
        /// </summary>
        public int WrongCount
        { private set; get; }

        public TestQuestion CurrentQuestion { get; private set; } = new TestQuestion();

        public override void GetItems(int pageSize, int pageIndex)
        {
            CurrentQuestion = new TestQuestion();
            Items = new AdvancedObservableCollection<TestAnswer>();


            switch (pageIndex)
            {
                case 1:
                    {

                        var correctAnswers =
                            QuestionsGenerator.GenerateFirstQuestion(null);
                        var answerId = wrongAnswerId(PageIndex, correctAnswers);

                        CurrentQuestion = QuestionsGenerator.GenerateFirstQuestion(answerId);

                        break;
                    }
                case 2:
                    {
                        var correctAnswers =
                            QuestionsGenerator.GenerateSecondQuestion(null);
                        var answerId = wrongAnswerId(PageIndex, correctAnswers);

                        CurrentQuestion = QuestionsGenerator.GenerateSecondQuestion(answerId);
                        
                        break;
                    }
                case 3:
                    {
                        var correctAnswers =
                            QuestionsGenerator.GenerateThirdQuestion(null);
                        var answerId = wrongAnswerId(PageIndex, correctAnswers);

                        CurrentQuestion = QuestionsGenerator.GenerateThirdQuestion(answerId);
                        break;
                    }

                case 4:
                    {
                        var correctAnswers =
                            QuestionsGenerator.GenerateFourthQuestion(null);
                        var answerId = wrongAnswerId(PageIndex, correctAnswers);

                        CurrentQuestion = QuestionsGenerator.GenerateFourthQuestion(answerId);
                        break;
                    }

                case 5:
                    {
                        var correctAnswers =
                            QuestionsGenerator.GenerateFifthQuestion(null);
                        var answerId = wrongAnswerId(PageIndex, correctAnswers);


                        CurrentQuestion = QuestionsGenerator.GenerateFifthQuestion(answerId);
                        break;
                    }
                case 6:
                    {
                        var correctAnswers =
                            QuestionsGenerator.GenerateSixthQuestion(null);
                        var answerId = wrongAnswerId(PageIndex, correctAnswers);


                        CurrentQuestion = QuestionsGenerator.GenerateSixthQuestion(answerId);
                        break;
                    }
            }

            Items.AddRange(CurrentQuestion.Answers);
            AddQuestionToList(CurrentQuestion);

        }

        private void AddQuestionToList(TestQuestion question)
        {
            if (Questions.Count < PageCount)
            {
                Questions.Add(question);
            }
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

                var answ = question.Answers;
                var correctId = answ.Where(a => a.IsCorrectAnswer);

                if (givenAnswerId != correctId.First().Id)
                {
                    wrongAnswerId = givenAnswerId;
                }
            }

            return wrongAnswerId;
        }



        /// <summary>
        /// Function to a count of incorrect answers
        /// </summary>
        public void CalculateAnswersCount()
        {
            WrongCount = CorrectCount = 0;

            for (int i = 0; i <= Questions.Count-1; i++)
            {
                var question = Questions[i];
                var answ = question.Answers;
                var correctId = answ.Where(a => a.IsCorrectAnswer);

                var givenAnswerId = GivenAnswers[i];

                if (givenAnswerId != correctId.First().Id)
                {
                    WrongCount++;
                }

                if (givenAnswerId == correctId.First().Id)
                {
                    CorrectCount++;
                }

            }

            //return count;
        }


    }

}