using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YucataTracker.Domain
{
	public class MatchResult
	{
		public virtual Match Match { get; protected internal set; }
		public virtual Player Player { get; protected internal set; }

		public virtual double PrimaryScore { get; set; }
		public virtual double TiebreakerScore { get; set; }
		public virtual double SecondaryTiebreakerScore { get; set; }

		public virtual double PointsShare { get; protected internal set; }
		public virtual double TournamentPoints { get; protected internal set; }

		public virtual int Rank { get; protected internal set; }
	}
}
