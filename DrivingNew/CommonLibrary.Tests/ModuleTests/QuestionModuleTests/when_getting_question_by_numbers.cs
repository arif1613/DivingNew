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
	public class when_getting_question_by_numbers:TestSetup
	{
		[TestMethod]
		public void Getting_question_by_given_two_number()
		{
			//Arrange

			var data = new List<QuestionsModel>
			{
				_questionModel1,_questionModel2
			}.AsQueryable();

			var questionTable = A.Fake<IDbSet<QuestionsModel>>(builder => 
                         builder.Implements(typeof (IEnumerable<QuestionsModel>)));
			A.CallTo(() => ((IQueryable<QuestionsModel>)questionTable).Provider).Returns(data.Provider);
			A.CallTo(() => ((IQueryable<QuestionsModel>)questionTable).Expression).Returns(data.Expression);
			A.CallTo(() => ((IQueryable<QuestionsModel>)questionTable).ElementType).Returns(data.ElementType);
			A.CallTo(() => ((IQueryable<QuestionsModel>)questionTable).GetEnumerator()).Returns(data.GetEnumerator());


			var drivingDatabase = A.Fake<IDrivingDatabase>();
			A.CallTo(() => drivingDatabase.QuestionsModels).Returns(questionTable);

			//Actual
			var questionModule = new GetQuestionModule(drivingDatabase);
			var result1 = questionModule.GetQuestionModelByTotalNumbers(2);

			//Assert
			Assert.IsNotNull(result1, "A result will be generated");
			Assert.AreEqual(result1.Count, 2, "Result contains correct numbers");
		}

		[TestMethod]
		public void Getting_question_by_given_three_number()
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
			var result2 = questionModule.GetQuestionModelByTotalNumbers(3);

			//Assert
			Assert.IsNotNull(result2, "A result will be generated");
			Assert.AreEqual(result2.Count, 2, "Result contains correct numbers");
		}
	}
}
