using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain;

namespace YucataTracker.Domain
{
	public class MatchResult : IEquatable<MatchResult>, IComparable<MatchResult>
	{
		protected internal MatchResult() { }

		public MatchResult(Match m, Player p)
		{
			Check.Require(null != m);
			Check.Require(null != p);
			this.Match = m;
			this.Player = p;
			p.MatchResults.Add(this);
		}


		public virtual Match Match { get; protected internal set; }
		public virtual Player Player { get; protected internal set; }

		public virtual double PrimaryScore { get; set; }
		public virtual double TiebreakerScore { get; set; }
		public virtual double SecondaryTiebreakerScore { get; set; }

		public virtual double PointsShare { get; protected internal set; }
		public virtual double TournamentPoints { get; protected internal set; }

		public virtual int Rank { get; protected internal set; }

		#region IEquatable<MatchResult> Members

		public bool Equals(MatchResult other)
		{
			if (other == null) return false;
			return (this.Match == other.Match && this.Player == other.Player);
		}

		public override int GetHashCode()
		{
			return this.Match.GetHashCode() + this.Player.GetHashCode();
		}

		#endregion

		#region IComparable<MatchResult> Members

		/// <summary>
		/// Compare using the Player object, so MatchResults are presented in the order the players are.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(MatchResult other)
		{
			if (other == null) return -1;
			return this.Player.CompareTo(other.Player);
		}

		#endregion
	}
}
