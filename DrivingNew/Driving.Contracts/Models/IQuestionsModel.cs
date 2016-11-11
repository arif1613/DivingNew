using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Driving.Contracts.Models
{
	public interface IQuestionsModel
	{
		[Key]
		Guid Id { get; set; }
		long QuestionNumber { get; set; }
		string Chapter { get; set; }
		string Question { get; set; }
		ICollection<AnswerModel> Options { get; set; }
		string ImageLink { get; set; }
		bool IsChecked { get; set; }
	}
}
