using System.Collections.Generic;
using YucataTracker.Domain;

namespace YucataTracker.Tasks.Queries
{
	public interface IGetAllGamesQuery
	{
		IList<Game> ListAll();
	}
}
