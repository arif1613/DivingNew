using System;
using System.ComponentModel.DataAnnotations;

namespace Driving.Contracts.Models
{
	public class AnswerModel:IAnswerModel
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public int OptionId { get; set; }
		[Required]
		public string Option { get; set; }
		[Required]
		public bool IsAnswer { get; set; }
	}
}
