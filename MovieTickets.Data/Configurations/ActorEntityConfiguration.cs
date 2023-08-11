using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTickets.Data.EntityModels;

namespace MovieTickets.Data.Configurations
{
	public class ActorEntityConfiguration : IEntityTypeConfiguration<Actor>
	{
		public void Configure(EntityTypeBuilder<Actor> builder)
		{
			//builder.HasData(GenerateActors());
		}
		private Actor[] GenerateActors()
		{
			ICollection<Actor> actors = new List<Actor>();

			Actor actor;

			actor = new Actor()
			{
				Id = 1,
				Name = "Actor 1",
				Description = "This is the description of the first Actor",
				ImageUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
			};
			actors.Add(actor);

			actor = new Actor()
			{
				Id = 2,
				Name = "Actor 2",
				Description = "This is the description of the first Actor",
				ImageUrl = "http://dotnethow.net/images/actors/actor-2.jpeg",
			};
			actors.Add(actor);

			actor = new Actor()
			{
				Id = 3,
				Name = "Actor 3",
				Description = "This is the description of the first Actor",
				ImageUrl = "http://dotnethow.net/images/actors/actor-3.jpeg",
			};
			actors.Add(actor);

			actor = new Actor()
			{
				Id = 4,
				Name = "Actor 4",
				Description = "This is the description of the first Actor",
				ImageUrl = "http://dotnethow.net/images/actors/actor-4.jpeg",
			};
			actors.Add(actor);

			actor = new Actor()
			{
				Id = 5,
				Name = "Actor 5",
				Description = "This is the description of the first Actor",
				ImageUrl = "http://dotnethow.net/images/actors/actor-5.jpeg",
			};
			actors.Add(actor);

			return actors.ToArray();
		}
	}
}
