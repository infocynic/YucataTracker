using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YucataTracker.Tasks.Queries
{
	public interface IGetGameByIDQuery
	{
		Domain.Game GetGame(int GameID);
	}
}
