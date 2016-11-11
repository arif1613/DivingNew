using System;

namespace Driving.Contracts.Models
{
	public interface IAnswerModel
	{
		Guid Id { get; set; }
		int OptionId { get; set; }
		string Option { get; set; }
		bool IsAnswer { get; set; }
	}
}
