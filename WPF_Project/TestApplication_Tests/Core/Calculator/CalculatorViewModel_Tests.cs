using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApplication_Tests.Core.Calculator
{
    [TestClass]
    public class CalculatorViewModel_Tests
    {
        CalculatorViewModel model;
        const string brackets = "()";

        public CalculatorViewModel_Tests()
        {
            model = new CalculatorViewModel();
        }

        /// <summary>
        /// Tests to apply different expressions
        /// </summary>
        [TestMethod()]
        public void ApplyExpressionTests()
        {
            string expression = "(12 + 4)";
            model.SetExpression.Execute(expression);
            Assert.AreEqual(model.Expression, expression);

            expression = "()";
            ClearSetExpresion(expression);
            Assert.AreEqual(model.Expression, model.LeftBracket);

            expression = ".";
            ClearSetExpresion(expression);
            Assert.AreEqual(model.Expression, model.ZeroDot);
        }


        /// <summary>
        /// Tests to apply brackets
        /// </summary>
        [TestMethod()]
        public void ApplyBracketsTests()
        {
            string expression = "";
            expression = brackets;

            ClearSetExpresion(expression);
            expression = brackets;
            model.SetExpression.Execute(expression);
            expression = brackets;
            model.SetExpression.Execute(expression);
            Assert.AreEqual(model.Expression, "(((");

            expression = "3";
            model.SetExpression.Execute(expression);
            expression = brackets;
            model.SetExpression.Execute(expression);
            Assert.AreEqual(model.Expression, "(((3)");

            expression = brackets;
            model.SetExpression.Execute(expression);
            Assert.AreEqual(model.Expression, "(((3))");

            expression = brackets;
            model.SetExpression.Execute(expression);
            Assert.AreEqual(model.Expression, "(((3)))");

            expression = brackets;
            model.SetExpression.Execute(expression);
            Assert.AreEqual(model.Expression, "(((3)))" + model.Mult + model.LeftBracket);
        }


        /// <summary>
        /// Tests to apply minus sign
        /// </summary>
        [TestMethod()]
        public void ApplyPlusMinusTests()
        {
            string expression = "";
            const string three = "3";
            model.ApplyNegativeSign.Execute(null);
            Assert.AreEqual(model.Expression, model.MinusString);

            expression = three;
            model.SetExpression.Execute(expression);
            Assert.AreEqual(model.Expression, model.MinusString + three);

            model.ApplyNegativeSign.Execute(null);
            Assert.AreEqual(model.Expression, three);

            model.ApplyNegativeSign.Execute(null);
            Assert.AreEqual(model.Expression, model.MinusString + three);

            expression = model.Plus;
            model.SetExpression.Execute(expression);
            Assert.AreEqual(model.Expression, model.MinusString + three + model.Plus);

            model.ApplyNegativeSign.Execute(null);
            Assert.AreEqual(model.Expression, model.MinusString + three + model.Plus + model.MinusString);
        }

        /// <summary>
        /// Tests to compute result
        /// </summary>
        [TestMethod()]
        public void ComputeTests()
        {
            var expression = "3 +5.6";
            model.SetExpression.Execute(expression);
            model.ComputeExpression.Execute(null);
            Assert.AreEqual(model.Result, GetResultString("8.6"));

            model.ApplyNegativeSign.Execute(null);
            Assert.AreEqual(model.Expression, "3 +(-5.6");

            model.SetExpression.Execute(model.Mult);
            model.DeleteSymbol.Execute(null);
            Assert.AreEqual(model.Expression, "3 +(-5.6");

            model.ComputeExpression.Execute(null);
            Assert.AreEqual(model.Result, GetResultString(model.WrongFormat));

            ClearSetExpresion("3 +(-5.6*3");
            model.SetExpression.Execute(brackets);
            Assert.AreEqual(model.Expression, "3 +(-5.6*3)");

            model.ComputeExpression.Execute(null);
            Assert.AreEqual(model.Result, GetResultString("-13.8"));

        }

        /// <summary>
        /// Returns formatted string result
        /// </summary>
        private string GetResultString(string str)
        {
            return model.Equal + str;
        }

        /// <summary>
        /// Calls clear and set expression commands
        /// </summary>
        private void ClearSetExpresion(string expression)
        {
            model.ClearExpression.Execute(null);
            model.SetExpression.Execute(expression);
        }
    }
}
