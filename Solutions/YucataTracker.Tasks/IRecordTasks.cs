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
		
		void RecordYucataIDs(MatchOverviewViewModel vm);

		void MarkAllInvited(MatchOverviewViewModel vm);

		void MarkAllPlaying(MatchOverviewViewModel vm);

		void UpdateMatchDetails(MatchDetailViewModel vm);
	}
}
