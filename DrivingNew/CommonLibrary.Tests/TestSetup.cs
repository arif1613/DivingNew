using System;
using System.Collections.Generic;
using Driving.Contracts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonLibrary.Tests
{
	public class TestSetup
	{
		public Guid _questionId1, _questionId2, _answerId1, _answerId2, _answerId3;
		public QuestionsModel _questionModel1, _questionModel2;
		public AnswerModel _answerModel1, _answerModel2, _answerModel3;

		[TestInitialize]
		public void TestInitialize()
		{
			_questionId1 = Guid.NewGuid();
			_questionId2 = Guid.NewGuid();
			_answerId1 = Guid.NewGuid();
			_answerId2 = Guid.NewGuid();
			_answerId3 = Guid.NewGuid();



			_answerModel1 = new AnswerModel
			{
				Id = _answerId1,
				IsAnswer = false,
				Option = "this is answer1",
				OptionId = 1
			};
			_answerModel2 = new AnswerModel
			{
				Id = _answerId2,
				IsAnswer = true,
				Option = "this is answer2",
				OptionId = 2
			};

			_answerModel3 = new AnswerModel
			{
				Id = _answerId3,
				IsAnswer = false,
				Option = "this is answer3",
				OptionId = 3
			};

			_questionModel1 = new QuestionsModel
			{
				Chapter = "ch1",
				Id = _questionId1,
				ImageLink = null,
				IsChecked = false,
				Options = new List<AnswerModel> { _answerModel1, _answerModel2 },
				Question = "first question",
				QuestionNumber = 1
			};
			_questionModel2 = new QuestionsModel
			{
				Chapter = "ch2",
				Id = _questionId2,
				ImageLink = null,
				IsChecked = false,
				Options = new List<AnswerModel> { _answerModel1, _answerModel2, _answerModel3 },
				Question = "second question",
				QuestionNumber = 2
			};
		}
	}
}
