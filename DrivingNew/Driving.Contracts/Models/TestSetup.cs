using System;
using System.Collections.Generic;

namespace Driving.Contracts.Models
{
	public class TestSetup:ITestSetup
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int TotalQuestions { get; set; }
		public List<QuestionsModel> Questions { get; set; }
	}
}
