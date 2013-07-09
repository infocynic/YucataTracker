using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YucataTracker.Tasks.Queries
{
	public interface IGetMatchesByUserAndGameQuery
	{
		IList<Domain.Match> GetMatchesByUserIDAndGameID(string BggID, int GameID);
	}
}
