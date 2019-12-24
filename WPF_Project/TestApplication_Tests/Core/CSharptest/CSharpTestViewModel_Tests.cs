using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApplication_Tests.Core.CSharptest
{
    [TestClass]
    public class CSharpTestViewModel_Tests
    {
        CSharpTestViewModel model;
        public CSharpTestViewModel_Tests()
        {
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            model = ViewModelLocator.Instance.CSharpTestViewModel;
        }

        /// <summary>
        /// Tests to perform questions
        /// </summary>
        [TestMethod()]
        public void ApplyNextQuestionTests()
        {
            //First question 
            model.TestSelectionDataContext.SelectedItemId = 1;
            model.NextQuestionCommand.Execute(null);

            //Second question 
            model.TestSelectionDataContext.SelectedItemId = 2;
            model.NextQuestionCommand.Execute(null);

            //Third question 
            model.TestSelectionDataContext.SelectedItemId = 3;
            model.NextQuestionCommand.Execute(null);

            //Fourth question 
            model.TestSelectionDataContext.SelectedItemId = 4;
            model.NextQuestionCommand.Execute(null);

            //Fifth question 
            model.TestSelectionDataContext.SelectedItemId = 1;
            model.NextQuestionCommand.Execute(null);

            //Sixth question 
            model.TestSelectionDataContext.SelectedItemId = 2;
            model.NextQuestionCommand.Execute(null);

            Assert.AreEqual(model.TestSelectionDataContext.CorrectCount, 2);
            Assert.AreEqual(model.TestSelectionDataContext.WrongCount, 4);

        }
    }
}
