using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using YucataTracker.Domain;

namespace YucataTracker.ViewModels
{
	public class MatchOverviewViewModel
	{
		[Required]
		public string BggID { get; set; }
		public int GameID { get; set; }

		public MatchOverviewViewModel() { }

		public MatchOverviewViewModel(IList<Match> Matches, string BggID)
		{
			Match m = Matches.First(); //yes this will crash, deliberately, if Matches is empty
			GameID = m.Game.Id;
			this.BggID = BggID;
			this.Matches = new List<MatchDTO>();
			this.Matches.AddRange(Matches.Select(ma => new MatchDTO(ma)));
		}

		public List<MatchDTO> Matches { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// The model binder can only work with this if we manually generate fields like 
		/// GameIDToYucataID_Dictionary[0].Key (hidden)
		/// GameIDToYucataID_Dictionary[0].Value (text box)
		/// </remarks>
		public Dictionary<int, int> GameIDToYucataID_Dictionary { get; set; }
	}
}
