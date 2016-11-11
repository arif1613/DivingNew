using System;
using System.Collections.Generic;
using Driving.Contracts.Models;

namespace CommonLibrary.Modules
{
	public interface IGetQuestionModule
	{
		QuestionsModel GetQuestionModelById(Guid id);
		List<QuestionsModel> GetQuestionModelByTotalNumbers(int totalQuestions);
		List<QuestionsModel> GetQuestionModelByTotalNumbersAndChapter(string chaptername,int totalQuestions);
		QuestionsModel GetQuestionModelByQuestion(string question);
		List<QuestionsModel> GetQuestionModelsByIds(List<Guid> ids);
		List<QuestionsModel> GetQuestionModelsByChaptername(string chaptername);
	}
}
