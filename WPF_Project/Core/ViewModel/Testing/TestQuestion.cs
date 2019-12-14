using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Helpers;

namespace Core
{

    public class TestQuestion : BaseModel
    {
        private AdvancedObservableCollection<TestAnswer> _answers = new AdvancedObservableCollection<TestAnswer>();

        public string QuestionText { get; set; }
        public int QuestionId { get; set; }

        /// <summary>
        /// The answers list 
        /// </summary>
        public AdvancedObservableCollection<TestAnswer> Answers
        {
            get { return _answers; }
            set
            {
                _answers = value;
            }
        }
    }


    /// <summary>
    /// The class to create answers
    /// </summary>
    public class TestAnswer : SelectionItem
    {
        public string AnswerText { get; set; }
        //public int AnswerId { get; set; }
        public bool IsCorrectAnswer { get; set; }


        public Brush AnswerColor { get; set; }

        public TestAnswer()
        {

        }

        /// <summary>
        /// The class to create answers
        /// </summary>
        /// <param name="answerText">Text of answer</param>
        /// <param name="answerId">Answer's unique id</param>
        /// <param name="isCorrectAnswer">Is it right answer</param>
        public TestAnswer(string answerText, int answerId,
            Brush answerColor,
            bool isCorrectAnswer = false)
        {
            AnswerText = answerText;
            Id = answerId;
            IsCorrectAnswer = isCorrectAnswer;
            AnswerColor = answerColor ?? new SolidColorBrush(Colors.LimeGreen);

        }
    }



    /// <summary>
    /// Test questions with corret answers
    /// </summary>
    public class TestQuestions : BaseModel
    {
        private ObservableCollection<TestQuestion> _questions = new ObservableCollection<TestQuestion>();

        /// <summary>
        /// The questions list 
        /// </summary>
        public ObservableCollection<TestQuestion> Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
            }
        }

    }
}
