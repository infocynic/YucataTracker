using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YucataTracker.Domain;
using YucataTracker.ViewModels;

namespace YucataTracker.Tasks
{
	public interface IRecordTasks
	{
		IList<Game> GetListOfAllGames();

		Game GetGameById(int GameID);

		IList<Match> GetMatchesByUserIDAndGameID(string p1, int p2);

		MatchOverviewViewModel PrepareNewMatchOverviewModel(string BggID, int GameID);

		void RecordYucataIDs(MatchOverviewViewModel vm);

		void MarkAllInvited(MatchOverviewViewModel vm);

		void MarkAllPlaying(MatchOverviewViewModel vm);

		Match GetMatchById(int MatchId);

		MatchDetailViewModel PrepareMatchDetailViewModel(Match m, string BggID);

		void UpdateMatchDetails(MatchDetailViewModel vm);
	}
}
