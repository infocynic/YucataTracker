using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YucataTracker.Domain
{
	public enum MatchStatus
	{
		Unstarted,
		Invited,
		Playing,
		Complete,
		Cancelled
	}
}
