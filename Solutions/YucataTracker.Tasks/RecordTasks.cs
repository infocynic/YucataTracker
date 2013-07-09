using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using SharpArch.NHibernate;

namespace YucataTracker.Tasks
{
	public class RecordTasks : IRecordTasks
	{

		private ISession Sesssion = NHibernateSession.Current;

		#region IRecordTasks Members

		

		public void RecordYucataIDs(ViewModels.MatchOverviewViewModel vm)
		{
			throw new NotImplementedException();
		}

		public void MarkAllInvited(ViewModels.MatchOverviewViewModel vm)
		{
			throw new NotImplementedException();
		}

		public void MarkAllPlaying(ViewModels.MatchOverviewViewModel vm)
		{
			throw new NotImplementedException();
		}


		public void UpdateMatchDetails(ViewModels.MatchDetailViewModel vm)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
