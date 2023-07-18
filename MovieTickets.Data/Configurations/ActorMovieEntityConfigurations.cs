using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTickets.Data.EntityModels;

namespace MovieTickets.Data.Configurations
{
	public class ActorMovieEntityConfigurations : IEntityTypeConfiguration<ActorMovie>
	{
		public void Configure(EntityTypeBuilder<ActorMovie> builder)
		{
			builder.HasKey(k => new { k.MovieId, k.ActorId });

			builder.HasOne(x => x.Movie)
			.WithMany(a => a.ActorMovies)
			.HasForeignKey(x => x.MovieId);

			builder.HasOne(x => x.Actor)
			.WithMany(a => a.ActorMovies)
			.HasForeignKey(a => a.ActorId);

			builder.HasData(GenerateActorMovie());
		}

		private ActorMovie[] GenerateActorMovie()
		{
			ICollection<ActorMovie> actorMovies = new List<ActorMovie>();

			ActorMovie actorMovie;

			actorMovie = new ActorMovie()
			{
				ActorId = 1,
				MovieId = 1
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 3,
				MovieId = 1
			};
			actorMovies.Add(actorMovie);


			actorMovie = new ActorMovie()
			{
				ActorId = 1,
				MovieId = 2
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 4,
				MovieId = 2
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 1,
				MovieId = 3
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 2,
				MovieId = 3
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 5,
				MovieId = 3
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 2,
				MovieId = 4
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 3,
				MovieId = 4
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 4,
				MovieId = 4
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 2,
				MovieId = 5
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 3,
				MovieId = 5
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 4,
				MovieId = 5
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 5,
				MovieId = 5
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 3,
				MovieId = 6
			};
			actorMovies.Add(actorMovie);

			actorMovie = new ActorMovie()
			{
				ActorId = 4,
				MovieId = 6
			};
			actorMovies.Add(actorMovie);


			actorMovie = new ActorMovie()
			{
				ActorId = 5,
				MovieId = 6
			};
			actorMovies.Add(actorMovie);

			return actorMovies.ToArray();
		}
	}
}
