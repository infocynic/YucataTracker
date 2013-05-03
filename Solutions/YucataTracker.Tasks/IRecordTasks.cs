using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YucataTracker.Domain;

namespace YucataTracker.Tasks
{
	public interface IRecordTasks
	{
		IList<Game> GetListOfAllGames();

		Game GetGameById(int GameID);
	}
}
