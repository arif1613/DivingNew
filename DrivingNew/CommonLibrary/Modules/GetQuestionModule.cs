using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Driving.Contracts.Models;
using Driving.Contracts.Models.Depo;

namespace CommonLibrary.Modules
{
	public class GetQuestionModule : IGetQuestionModule
	{

		private readonly IDbSet<QuestionsModel> _questionsModels;


		public GetQuestionModule(IDrivingDatabase drivingDatabase)
		{
			_questionsModels = drivingDatabase.QuestionsModels;
		}

		public QuestionsModel GetQuestionModelById(Guid id)
		{
			var model = _questionsModels.Find(id);
			if (model == null)
			{
				throw new Exception("No question with given ID found.");
			}
			return model;
		}

		public List<QuestionsModel> GetQuestionModelByTotalNumbers(int totalQuestions)
		{
			var dbTable = _questionsModels.Include(r => r.Options)
				.OrderBy(r => r.QuestionNumber).Distinct().ToArray();
			var randomnumber = new Random();
			if (totalQuestions > dbTable.Count())
			{
				totalQuestions = dbTable.Count();
			}
			var randomList = dbTable.Select(r => r.QuestionNumber).Shuffle().Take(totalQuestions);
			var questionsList = new List<QuestionsModel>();
			foreach (var number in randomList)
			{
				var question = dbTable.FirstOrDefault(r => r.QuestionNumber == number);
				if (question != null)
				{
					questionsList.Add(question);
				}

			}
			return questionsList.ToList();
		}

		public List<QuestionsModel> GetQuestionModelByTotalNumbersAndChapter(string chaptername, int totalQuestions)
		{
			var dbTable = _questionsModels.Include(r => r.Options).Where(r => r.Chapter == chaptername).
				OrderBy(r => r.QuestionNumber).Distinct().ToArray();
			if (totalQuestions > dbTable.Count())
			{
				totalQuestions = dbTable.Count();
			}
			var randomList = dbTable.Select(r => r.QuestionNumber).Shuffle().Take(totalQuestions);
			var questionsList = new List<QuestionsModel>();
			foreach (var number in randomList)
			{
				var question = dbTable.FirstOrDefault(r => r.QuestionNumber == number);
				if (question != null)
				{
					questionsList.Add(question);
				}

			}
			return questionsList.ToList();
		}

		public QuestionsModel GetQuestionModelByQuestion(string question)
		{
			var model = _questionsModels.FirstOrDefault(r => r.Question == question);
			if (model != null)
			{
				return model;
			}
			throw new Exception("Question did not found.");
		}

		public List<QuestionsModel> GetQuestionModelsByIds(List<Guid> ids)
		{
			var dbTable = _questionsModels.Include(r => r.Options).OrderBy(r=>r.QuestionNumber).Distinct().ToList();
			return dbTable.ToList();
		}

		public List<QuestionsModel> GetQuestionModelsByChaptername(string chaptername)
		{
			var dbTable = _questionsModels.Include(r => r.Options).Where(r=>r.Chapter==chaptername)
				.OrderBy(r => r.QuestionNumber).Distinct().ToList();
			return dbTable.ToList();
		}
	}



	public static class EnumerableExtensions
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			return source.Shuffle(new Random());
		}

		private static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
		{
			if (source == null) throw new ArgumentNullException("source");
			if (rng == null) throw new ArgumentNullException("rng");

			return source.ShuffleIterator(rng);
		}

		private static IEnumerable<T> ShuffleIterator<T>(
			this IEnumerable<T> source, Random rng)
		{
			var buffer = source.ToList();
			for (var i = 0; i < buffer.Count; i++)
			{
				var j = rng.Next(i, buffer.Count);
				yield return buffer[j];

				buffer[j] = buffer[i];
			}
		}
	}
}
