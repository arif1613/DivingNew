using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CommonLibrary.Modules;
using Driving.Contracts.Models;
using Driving.Contracts.Models.Depo;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonLibrary.Tests.ModuleTests.QuestionModuleTests
{
	[TestClass]
	public class when_getting_questions_by_ID_List:TestSetup
	{
		[TestMethod]
		public void Getting_question_by_given_question()
		{
			//Arrange

			var data = new List<QuestionsModel>
			{
				_questionModel1,_questionModel2
			}.AsQueryable();

			var questionTable = A.Fake<IDbSet<QuestionsModel>>(builder =>
						 builder.Implements(typeof(IEnumerable<QuestionsModel>)));
			A.CallTo(() => ((IQueryable<QuestionsModel>)questionTable).Provider).Returns(data.Provider);
			A.CallTo(() => ((IQueryable<QuestionsModel>)questionTable).Expression).Returns(data.Expression);
			A.CallTo(() => ((IQueryable<QuestionsModel>)questionTable).ElementType).Returns(data.ElementType);
			A.CallTo(() => ((IQueryable<QuestionsModel>)questionTable).GetEnumerator()).Returns(data.GetEnumerator());


			var drivingDatabase = A.Fake<IDrivingDatabase>();
			A.CallTo(() => drivingDatabase.QuestionsModels).Returns(questionTable);

			//Actual
			var questionModule = new GetQuestionModule(drivingDatabase);
			var result = questionModule.GetQuestionModelsByIds(new List<Guid>{_questionId1,_questionId2});

			//Assert
			Assert.IsNotNull(result, "A result will be generated");
			Assert.IsTrue(result.Contains(_questionModel1), "Result contains correct question");
			Assert.IsTrue(result.Contains(_questionModel2), "Result contains correct question");
		}
	}
}
