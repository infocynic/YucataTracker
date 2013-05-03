using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using YucataTracker.Domain;

namespace YucataTracker.ViewModels
{
	public class SelectPlayerViewModel
	{


		public SelectPlayerViewModel(Game g, string BggID)
		{
			// TODO: Complete member initialization
			this.GameName = g.Name;
			this.GameId = g.Id;
			this.BggID = BggID;
		}

		public string GameName { get; set; }

		public int GameId { get; set; }

		[Required]
		public string BggID { get; set; }
	}
}
