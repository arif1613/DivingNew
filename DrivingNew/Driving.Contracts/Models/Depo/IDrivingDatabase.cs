using System.Data.Entity;

namespace Driving.Contracts.Models.Depo
{
	public interface IDrivingDatabase
	{
		IDbSet<QuestionsModel> QuestionsModels { get; set; }
		void Savechanges();
	}
}
