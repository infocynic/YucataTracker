using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using YucataTracker.Domain;
using YucataTracker.ViewModels.Helpers;

namespace YucataTracker.ViewModels
{
	public class MatchDetailViewModel: IValidatableObject
	{
		public int MatchId { get; set; }
		public int GameId { get; set; }
		public string BggId { get; set; }
		public int NumPlayers { get; set; }

		public IList<double> PrimaryScores { get; set; }
		public IList<double> FirstTiebreakerScores { get; set; }
		public IList<double> SecondTiebreakerScores { get; set; }

		public IList<PlayerDTO> Players { get; set; }

		public IEnumerable<SelectListItem> Statuses { get; private set; }

		public MatchStatus Status { get; set; }

		public MatchDetailViewModel()
		{
			Statuses = Status.ToSelectList();

			this.PrimaryScores = new List<double>();
			this.FirstTiebreakerScores = new List<double>();
			this.SecondTiebreakerScores = new List<double>();
			this.Players = new List<PlayerDTO>();
		}

		public MatchDetailViewModel(Match m, string BggId) : this()
		{
			this.MatchId = m.Id;
			this.GameId = m.Game.Id;
			this.BggId = BggId;
			this.Status = m.MatchStatus;
			this.NumPlayers = m.Players.Count();

			this.PrimaryScores = m.MatchResults.Select(mr => mr.PrimaryScore).ToList();
			this.FirstTiebreakerScores = m.MatchResults.Select(mr => mr.TiebreakerScore).ToList();
			this.SecondTiebreakerScores = m.MatchResults.Select(mr => mr.SecondaryTiebreakerScore).ToList();
		}

		#region IValidatableObject Members

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			List<ValidationResult> results = new List<ValidationResult>();
			if (this.PrimaryScores.Count > 0 && this.PrimaryScores.Count < NumPlayers)
			{
				results.Add(new ValidationResult("The number of primary scores must match the number of players."));
			}
			if (this.FirstTiebreakerScores.Count > 0 && this.FirstTiebreakerScores.Count < NumPlayers)
			{
				results.Add(new ValidationResult("The number of first tiebreaker scores must match the number of players."));
			}
			if (this.SecondTiebreakerScores.Count > 0 && this.SecondTiebreakerScores.Count < NumPlayers)
			{
				results.Add(new ValidationResult("The number of second tiebreaker scores must match the number of players."));
			}
			if (this.Status == MatchStatus.Complete && this.PrimaryScores.Count < NumPlayers)
			{
				results.Add(new ValidationResult("You cannot set the game status to complete without entering final scores.", new[] { "Status" }));
			}
			return results;
		}

		#endregion
	}
}
