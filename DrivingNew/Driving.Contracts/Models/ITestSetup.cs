using System;
using System.Collections.Generic;

namespace Driving.Contracts.Models
{
	public interface ITestSetup
	{
		Guid Id { get; set; }
		string Username { get; set; }
		DateTime StartTime { get; set; }
		DateTime EndTime { get; set; }
		int TotalQuestions { get; set; }
		List<QuestionsModel> Questions { get; set; }
	}
}
