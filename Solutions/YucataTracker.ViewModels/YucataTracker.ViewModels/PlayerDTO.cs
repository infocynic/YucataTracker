using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YucataTracker.ViewModels
{
	public class PlayerDTO
	{
		public PlayerDTO() { }

		public PlayerDTO(Domain.Player p) : this()
		{
			this.BggID = p.BggID;
			this.YucataID = p.YucataID;
			this.Id= p.Id;
		}

		public string YucataID { get; set; }

		public string BggID { get; set; }

		public int Id { get; set; }
	}
}
