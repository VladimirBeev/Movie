using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTickets.Data.EntityModels;

namespace MovieTickets.Data.Configurations
{
	public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			builder.Property(m => m.Price)
			.HasPrecision(6, 2);

			builder.HasData(GenerateMovies());
		}

		private Movie[] GenerateMovies()
		{
			ICollection<Movie> movies = new List<Movie>();

			Movie movie;

			movie = new Movie()
			{
				Id = 1,
				Title = "Life",
				Description = "As astronauts discover the first evidence of extra-terrestrial life on Mars, " +
				"they begin realising that the life form is extremely intelligent and hostile.",
				Price = 39,
				ImageUrl = "https://pics.filmaffinity.com/Life-707248688-large.jpg",
				StartDate = DateTime.Now.AddDays(-10),
				EndDate = DateTime.Now.AddDays(10),
				CinemaId = 3,
				ProducerId = 3,
				MovieCategory = MovieCategory.Documentary
			};
			movies.Add(movie);

			movie = new Movie()
			{
				Id = 2,
				Title = "The Dark Knight",
				Description = "Batman/Bruce Wayne (Christian Bale) raises the stakes in his war on crime. " +
				"With the help of Lieutenant Jim Gordon (Gary Oldman) and District Attorney Harvey Dent (Aaron Eckhart), " +
				"Batman sets out to dismantle the remaining criminal organizations that plague the city streets. " +
				"The partnership proves to be effective, " +
				"but they soon find themselves prey to a reign of chaos unleashed by a rising criminal mastermind " +
				"known to the terrified citizens of Gotham as The Joker (Heath Ledger).",
				Price = 29,
				ImageUrl = "https://pics.filmaffinity.com/The_Dark_Knight-102763119-large.jpg",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now.AddDays(3),
				CinemaId = 1,
				ProducerId = 1,
				MovieCategory = MovieCategory.Action
			};
			movies.Add(movie);

			movie = new Movie()
			{
				Id = 3,
				Title = "Paycheck",
				Description = "Michael Jennings (Ben Affleck) is a high-paid engineer who works on hush-hush computer inventions and technology for shady companies. Later, " +
				"his memory is wiped clean, so he has no recollection of his work. His so-called friend Rethrick " +
				"(Aaron Eckhardt) offers him enough money to retire by working on a project at Rethrick's company, " +
				"Allcom. When Jennings emerges three years later, sans memory, he tries to collect his paycheck. At " +
				"the bank, he's handed a manila envelope filled with cryptic items he doesn't recognize, and told he " +
				"voluntarily forfeited his entire paycheck. He also has a stunning girlfriend named Dr. Rachel Porter " +
				"(Uma Thurman) who is likewise ensnared in the conspiracy. Jennings must somehow piece together the clues " +
				"he left for himself, and find out why everyone is out to kill him... Adapted from a mind-bending " +
				"sci-fi thriller novel by Philip K. Dick.",
				Price = 19,
				ImageUrl = "https://pics.filmaffinity.com/Paycheck-957568097-large.jpg",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now.AddDays(7),
				CinemaId = 4,
				ProducerId = 4,
				MovieCategory = MovieCategory.Horror
			};
			movies.Add(movie);

			movie = new Movie()
			{
				Id = 4,
				Title = "Safe House",
				Description = "A young CIA agent is tasked with looking after a fugitive in a safe house." +
				" But when the safe house is attacked, he finds himself on the run with his charge.",
				Price = 49,
				ImageUrl = "https://pics.filmaffinity.com/Safe_House-299293074-large.jpg",
				StartDate = DateTime.Now.AddDays(-10),
				EndDate = DateTime.Now.AddDays(-5),
				CinemaId = 1,
				ProducerId = 2,
				MovieCategory = MovieCategory.Documentary
			};
			movies.Add(movie);

			movie = new Movie()
			{
				Id = 5,
				Title = "Free Guy",
				Description = "When Guy, a bank teller, " +
				"learns that he is a non-player character in a bloodthirsty, " +
				"open-world video game, he goes on to become the hero of the story and takes the responsibility " +
				"of saving the world.",
				Price = 59,
				ImageUrl = "https://pics.filmaffinity.com/Free_Guy-297648487-large.jpg",
				StartDate = DateTime.Now.AddDays(-10),
				EndDate = DateTime.Now.AddDays(-2),
				CinemaId = 1,
				ProducerId = 3,
				MovieCategory = MovieCategory.Comedy
			};
			movies.Add(movie);

			movie = new Movie()
			{
				Id = 6,
				Title = "The Pope's Exorcist",
				Description = "Father Gabriele Amorth, chief exorcist for the Vatican, " +
				"battles Satan and innocent-possessing demons. A detailed portrait of a priest who " +
				"performed more than 100,000 exorcisms in his lifetime.",
				Price = 79,
				ImageUrl = "https://pics.filmaffinity.com/The_Pope_s_Exorcist-660382735-large.jpg",
				StartDate = DateTime.Now.AddDays(3),
				EndDate = DateTime.Now.AddDays(20),
				CinemaId = 1,
				ProducerId = 5,
				MovieCategory = MovieCategory.Drama
			};
			movies.Add(movie);

			return movies.ToArray();
		}
	}
}
