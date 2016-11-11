using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Driving.Contracts.Models
{
	public class QuestionsModel:IQuestionsModel
	{
		public Guid Id { get; set; }
		[Required]
		public long QuestionNumber { get; set; }
		[Required]
		public string Chapter { get; set; }
		[Required]
		public string Question { get; set; }
		[Required]
		public ICollection<AnswerModel> Options { get; set; }
		public string ImageLink { get;  set; }
		public bool IsChecked { get; set; }
	}
}
