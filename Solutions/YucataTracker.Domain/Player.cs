using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using SharpArch.Domain;
using SharpArch.Domain.DomainModel;
using YucataTracker.Domain.Attributes;

namespace YucataTracker.Domain
{
	public class Player : Entity, IComparable<Player>
	{
		protected internal Player()
		{
			this._matchResults = new HashSet<MatchResult>();
		}

		public Player(string BggId, string YucataId = null)
			: this()
		{
			Check.Require(BggId != null);
			this.BggID = BggId;
			this.YucataID = YucataId ?? BggId;
		}

		private ISet<MatchResult> _matchResults; 
		
		[Required, Indexed, Unique]
		public virtual string BggID { get; set; }

		[Required, Indexed, Unique]
		public virtual string YucataID { get; set; }

		public virtual IEnumerable<MatchResult> MatchResults { get { return _matchResults; } }

		public virtual bool AddMatchResult(MatchResult mr)
		{
			Check.Require(mr != null);
			return _matchResults.Add(mr);
		}

		public virtual bool DeleteMatchResult(MatchResult m)
		{
			return _matchResults.Remove(m);
		}

		#region IComparable<Player> Members

		public int CompareTo(Player other)
		{
			if (null == other) return -1;
			return this.YucataID.CompareTo(other.YucataID);
		}

		#endregion
	}
}
