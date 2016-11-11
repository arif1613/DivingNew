using System.Data.Entity;
using CommonLibrary.Modules;
using Driving.Contracts.Models;
using Driving.Contracts.Models.Depo;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonLibrary.Tests.ModuleTests.QuestionModuleTests
{
	[TestClass]
	public class when_getting_question_by_id:TestSetup
	{
		[TestMethod]
		public void Getting_question_by_valid_id()
		{
			//Arrange
		
			var questionTable = A.Fake<IDbSet<QuestionsModel>>();
			A.CallTo(() => questionTable.Find(_questionId1)).Returns(_questionModel1);
			A.CallTo(() => questionTable.Find(_questionId2)).Returns(_questionModel2);
			var drivingDatabase = A.Fake<IDrivingDatabase>();
			A.CallTo(() => drivingDatabase.QuestionsModels).Returns(questionTable);

			//Actual
			var questionModule = new GetQuestionModule(drivingDatabase);
			var result1 = questionModule.GetQuestionModelById(_questionId1);
			var result2 = questionModule.GetQuestionModelById(_questionId2);

			//Assert
			Assert.IsNotNull(result1, "A result will be generated");
			Assert.AreEqual(result1.Id, _questionId1, "Result contains correct id");
			Assert.AreEqual(result1.Question, _questionModel1.Question, "Result contains correct question");
			Assert.AreEqual(result1.Options, _questionModel1.Options, "Result contains correct options");

			Assert.IsNotNull(result2, "A result will be generated");
			Assert.AreEqual(result2.Id, _questionId2, "Result contains correct id");
			Assert.AreEqual(result2.Question, _questionModel2.Question, "Result contains correct question");
			Assert.AreEqual(result2.Options, _questionModel2.Options, "Result contains correct options");
		}
	}
}
