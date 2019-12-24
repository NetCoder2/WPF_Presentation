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
            var questionText = "Which of the following operator represents a conditional operation in C#?";
            var questionId = 1;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("?:", 1, null, true),
                                        new TestAnswer("is", 2, null),
                                        new TestAnswer("as", 3, null),
                                        new TestAnswer("*", 4, null),
                                    };

            FillWrongRedItem(wrongAnswerId, answers);

            return CreateQuestion(questionText, questionId, answers.ToArray());
        }




        public static TestQuestion GenerateSecondQuestion(int? wrongAnswerId)
        {
            var questionText = "Which of the following converts a type to a small floating point number in C#?";
            var questionId = 2;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("ToInt64", 1, null),
                                        new TestAnswer("ToSbyte", 2, null),
                                        new TestAnswer("ToSingle", 3, null, true),
                                        new TestAnswer("ToInt32", 4, null),
                                    };

            FillWrongRedItem(wrongAnswerId, answers);

            return CreateQuestion(questionText, questionId, answers.ToArray());
        }

        public static TestQuestion GenerateThirdQuestion(int? wrongAnswerId)
        {
            var questionText = "Which of the following is the default access specifier of a class?";
            var questionId = 3;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("Private", 1, null),
                                        new TestAnswer("Public", 2, null),
                                        new TestAnswer("Protected", 3, null),
                                        new TestAnswer("Internal", 4, null, true),
                                    };
            FillWrongRedItem(wrongAnswerId, answers);
            return CreateQuestion(questionText, questionId, answers.ToArray());
        }

        public static TestQuestion GenerateFourthQuestion(int? wrongAnswerId)
        {
            var questionText = "Which of the following defines unboxing correctly?";
            var questionId = 4;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("When a value type is converted to object type, it is called unboxing", 1, null),
                                        new TestAnswer("When an object type is converted to a value type, it is called unboxing", 2, null, true),
                                        new TestAnswer("Both of the above", 3, null),
                                        new TestAnswer("None of the above", 4, null),
                                    };
            FillWrongRedItem(wrongAnswerId, answers);
            return CreateQuestion(questionText, questionId, answers.ToArray());
        }

        public static TestQuestion GenerateFifthQuestion(int? wrongAnswerId)
        {
            var questionText = "Which of the following preprocessor directive allows creating " +
                "a compound conditional directive in C#?";
            var questionId = 5;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("elif", 1, null, true),
                                        new TestAnswer("define", 2, null),
                                        new TestAnswer("if", 3, null),
                                        new TestAnswer("else", 4, null),
                                    };
            FillWrongRedItem(wrongAnswerId, answers);
            return CreateQuestion(questionText, questionId, answers.ToArray());
        }

        public static TestQuestion GenerateSixthQuestion(int? wrongAnswerId)
        {
            var questionText = "Which of the following preprocessor directive allows " +
                "generating a level one warning from a specific location in your code in C#?";
            var questionId = 5;

            var answers = new List<TestAnswer>
                                    {
                                        new TestAnswer("warning", 1, null, true),
                                        new TestAnswer("region", 2, null),
                                        new TestAnswer("line", 3, null),
                                        new TestAnswer("error", 4, null),
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
