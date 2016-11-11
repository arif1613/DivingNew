using System.Data.Entity;

namespace Driving.Contracts.Models.Depo
{
	public class DrivingDatabase : DbContext, IDrivingDatabase
	{
		public IDbSet<QuestionsModel> QuestionsModels { get; set; }
		public void Savechanges()
		{
			SaveChanges();
		}
	}
}
