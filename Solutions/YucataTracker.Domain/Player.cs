using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace YucataTracker.Domain
{
	public class Player : Entity
	{
		public Player()
		{
			this._matches = new HashSet<Match>();
		}

		private ISet<Match> _matches; 
		
		public virtual string BggID { get; set; }
		public virtual string YucataID { get; set; }

		public virtual ISet<Match> Matches { get { return _matches; } }
	}
}
