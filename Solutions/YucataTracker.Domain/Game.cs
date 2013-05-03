namespace YucataTracker.Domain
{
	using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;
using SharpArch.Domain.DomainModel;

    public class Game : Entity
    {

		protected Game() { this.Matches = new HashedSet<Match>(); }

		public Game(string Name)
			: this()
		{
			this.Name = Name;
		}

		[Required]
		public virtual string Name { get; set; }

		[Required]
		public virtual string BggUrl { get; set; }

		[Required, Range(2, 5)]
		public virtual int NumberOfPlayers { get; set; }

		[Required]
		public virtual string PrimaryScoreLabel { get; set; }

		[Required]
		public virtual SortDirection PrimaryScoreSort { get; set; }

		[Required]
		public virtual string FirstTiebreakerLabel { get; set; }

		[Required]
		public virtual SortDirection FirstTiebreakerSort { get; set; }

		public virtual string SecondTiebreakerLabel { get; set; }

		public virtual SortDirection SecondTiebreakerSort { get; set; }

		public virtual ISet<Match> Matches { get; private set; }
    }
}