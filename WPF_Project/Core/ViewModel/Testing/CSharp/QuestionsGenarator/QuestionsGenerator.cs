using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Core
{
    /// <summary>
    /// The class to genarate quations with answers 
    /// </summary>
    public static class QuestionsGenerator
    {
        public static TestQuestion GenerateFirstQuestion(int? wrongAnswerId)
        {
            var questionText = "Some question 1";
            var questionId = 1;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("Some answer 11", 1, null),
                                        new TestAnswer("Some answer 12", 2, null),
                                        new TestAnswer("Some answer 13", 3, null, true),
                                        new TestAnswer("Some answer 14", 4, null),
                                    };

            FillWrongRedItem(wrongAnswerId, answers);

            return CreateQuestion(questionText, questionId, answers.ToArray());
        }




        public static TestQuestion GenerateSecondQuestion(int? wrongAnswerId)
        {
            var questionText = "Some question 2";
            var questionId = 2;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("Some answer 21", 1, null),
                                        new TestAnswer("Some answer 22", 2, null),
                                        new TestAnswer("Some answer 23", 3, null),
                                        new TestAnswer("Some answer 24", 4, null, true),
                                    };

            FillWrongRedItem(wrongAnswerId, answers);

            return CreateQuestion(questionText, questionId, answers.ToArray());
        }

        public static TestQuestion GenerateThirdQuestion(int? wrongAnswerId)
        {
            var questionText = "Some question 3";
            var questionId = 3;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("Some answer 31", 1, null),
                                        new TestAnswer("Some answer 32", 2, null, true),
                                        new TestAnswer("Some answer 32", 3, null),
                                        new TestAnswer("Some answer 34", 4, null),
                                    };
            FillWrongRedItem(wrongAnswerId, answers);
            return CreateQuestion(questionText, questionId, answers.ToArray());
        }

        public static TestQuestion GenerateFourthQuestion(int? wrongAnswerId)
        {
            var questionText = "Some question 4";
            var questionId = 4;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("Some answer 41", 1, null),
                                        new TestAnswer("Some answer 42", 2, null, true),
                                        new TestAnswer("Some answer 42", 3, null),
                                        new TestAnswer("Some answer 44", 4, null),
                                    };
            FillWrongRedItem(wrongAnswerId, answers);
            return CreateQuestion(questionText, questionId, answers.ToArray());
        }

        public static TestQuestion GenerateFifthQuestion(int? wrongAnswerId)
        {
            var questionText = "Some question 5";
            var questionId = 5;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("Some answer 51", 1, null),
                                        new TestAnswer("Some answer 52", 2, null, true),
                                        new TestAnswer("Some answer 52", 3, null),
                                        new TestAnswer("Some answer 54", 4, null),
                                    };
            FillWrongRedItem(wrongAnswerId, answers);
            return CreateQuestion(questionText, questionId, answers.ToArray());
        }


        private static void FillWrongRedItem(int? wrongAnswerId, List<TestAnswer> answers)
        {
            if (wrongAnswerId != null)
            {
                answers.Where(id => id.Id == wrongAnswerId.Value).Single().AnswerColor =
                    new SolidColorBrush(Colors.Red);
            }
        }

        /// <summary>
        /// Generates question with answers 
        /// </summary>  
        /// <returns>TestQuestion</returns>
        public static TestQuestion CreateQuestion(string questionText, int idQuestion, params TestAnswer[] answers)
        {

            TestQuestion question = new TestQuestion();
            question.QuestionText = questionText;
            question.QuestionId = idQuestion;

            question.Answers.AddRange(answers);

            return question;

        }

    }
}
