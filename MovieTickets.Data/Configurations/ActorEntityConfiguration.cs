using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTickets.Data.EntityModels;

namespace MovieTickets.Data.Configurations
{
	public class ActorEntityConfiguration : IEntityTypeConfiguration<Actor>
	{
		public void Configure(EntityTypeBuilder<Actor> builder)
		{
			builder.HasData(GenerateActors());
		}
		private Actor[] GenerateActors()
		{
			ICollection<Actor> actors = new List<Actor>();

			Actor actor;

			actor = new Actor()
			{
				Id = 1,
				Name = "Ryan Reynolds",
				Description = "Ryan Rodney Reynolds OBC is a " +
				"Canadian and American actor, film producer, and businessman. " +
				"He began his career starring in the Canadian teen soap opera Hillside, " +
				"and had minor roles before landing the lead role on the sitcom Two Guys and a Girl between 1998 and 2001.",
				ImageUrl = "https://pics.filmaffinity.com/ryan_reynolds-279844037918521-nm_large.jpg",
			};
			actors.Add(actor);

			actor = new Actor()
			{
				Id = 2,
				Name = "Jake Gyllenhaal",
				Description = "Jacob Benjamin Gyllenhaal is an American actor. " +
				"Born into the Gyllenhaal family, he is the son of director Stephen Gyllenhaal and screenwriter " +
				"Naomi Foner, and his older sister is actress Maggie Gyllenhaal.",
				ImageUrl = "https://pics.filmaffinity.com/jake_gyllenhaal-173579980188358-nm_large.jpg",
			};
			actors.Add(actor);

			actor = new Actor()
			{
				Id = 3,
				Name = "Rebecca Ferguson",
				Description = "Rebecca Louisa Ferguson Sundström is a Swedish actress. " +
				"She began her acting career with the Swedish soap opera Nya tider and " +
				"went on to star in the slasher film Drowning Ghost.",
				ImageUrl = "https://pics.filmaffinity.com/rebecca_ferguson-273006559554882-nm_200.jpg",
			};
			actors.Add(actor);

			actor = new Actor()
			{
				Id = 4,
				Name = "Christian Bale",
				Description = "Christian Charles Philip Bale is an English actor. " +
				"Known for his versatility and physical transformations for his roles, " +
				"he has been a leading man in films of several genres. He has received various accolades, " +
				"including an Academy Award and two Golden Globe Awards.",
				ImageUrl = "https://pics.filmaffinity.com/christian_bale-146362426279095-nm_large.jpg",
			};
			actors.Add(actor);

			actor = new Actor()
			{
				Id = 5,
				Name = "Aaron Eckhart",
				Description = "Aaron Edward Eckhart is an American actor. " +
				"Born in Cupertino, California, Eckhart moved to the United Kingdom at an early age. " +
				"He began his acting career by performing in school plays, " +
				"before moving to Australia for his high school senior year.",
				ImageUrl = "https://pics.filmaffinity.com/aaron_eckhart-072135910642502-nm_large.jpg",
			};
			actors.Add(actor);

			return actors.ToArray();
		}
	}
}
