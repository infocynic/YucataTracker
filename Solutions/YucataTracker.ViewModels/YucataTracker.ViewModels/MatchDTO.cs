using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YucataTracker.ViewModels
{
	public class MatchDTO
	{
		

		public MatchDTO(Domain.Match ma) : this()
		{
			Players.AddRange(ma.Players.Select(p => new PlayerDTO(p)));
			this.Id = ma.Id;
		}

		public MatchDTO()
		{
			Players = new List<PlayerDTO>();
		}

		public List<PlayerDTO> Players { get; private set; }

		public int Id { get; set; }
	}
}
