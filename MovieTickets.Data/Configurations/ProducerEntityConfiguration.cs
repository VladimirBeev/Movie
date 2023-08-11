using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTickets.Data.EntityModels;

namespace MovieTickets.Data.Configurations
{
	public class ProducerEntityConfiguration : IEntityTypeConfiguration<Producer>
	{
		public void Configure(EntityTypeBuilder<Producer> builder)
		{
			builder.HasData(GenerateProducers());
		}

		private Producer[] GenerateProducers()
		{
			ICollection<Producer> producers = new List<Producer>();

			Producer producer;

			producer = new Producer()
			{
				Id = 1,
				Name = "Daniel Espinosa",
				Description = "Jorge Daniel Espinosa is a Swedish-Chilean film director, " +
				"screenwriter and film producer from Trångsund, Stockholm. He graduated from the " +
				"National Film School of Denmark in 2001. He notably directed the Sony's Marvel Universe " +
				"film Morbius starring Jared Leto and other films including Life, Easy Money, The Boxer, " +
				"Babylon Disease, Outside Love and Child 44.",
				ImageUrl = "https://pics.filmaffinity.com/daniel_espinosa-161586443111622-nm_large.jpg"
			};
			producers.Add(producer);

			producer = new Producer()
			{
				Id = 2,
				Name = "Christopher Nolan",
				Description = "Best known for his cerebral, often nonlinear, storytelling, acclaimed writer-director " +
				"Christopher Nolan was born on July 30, 1970, in London, England. Over the course of 15 years of " +
				"filmmaking, Nolan has gone from low-budget independent films to working on some of the biggest " +
				"blockbusters ever made.",
				ImageUrl = "https://pics.filmaffinity.com/christopher_nolan-055100338198118-nm_large.jpg"
			};
			producers.Add(producer);


			producer = new Producer()
			{
				Id = 3,
				Name = "John Woo",
				Description = "Born in southern China, John Woo grew up in Hong Kong, where he began his film " +
				"career as an assistant director in 1969, working for Shaw Brothers Studios. He directed his " +
				"first feature in 1973 and has been a prolific director ever since, working in a wide variety of " +
				"genres before A Better Tomorrow (1986) established his reputation as a master stylist specializing " +
				"in ultra-violent gangster films and thrillers, with hugely elaborate action scenes shot with " +
				"breathtaking panache. After gaining a cult reputation in the US with The Killer (1989), " +
				"Woo was offered a Hollywood contract. He now works in the US.",
				ImageUrl = "https://pics.filmaffinity.com/john_woo-168005725142890-nm_large.jpg"
			};
			producers.Add(producer);

			producer = new Producer()
			{
				Id = 4,
				Name = "Shawn Levy",
				Description = "Shawn Levy was born on July 23, 1968 in Montreal, Quebec, Canada. " +
				"He is a producer and director, known for Stranger Things (2016), Real Steel (2011), " +
				"and the Night at the Museum franchise. He is the founder and principal of 21 Laps Entertainment. " +
				"He is married to Serena Levy and they have four daughters.",
				ImageUrl = "https://pics.filmaffinity.com/shawn_levy-200697726875313-nm_large.jpg"
			};
			producers.Add(producer);

			producer = new Producer()
			{
				Id = 5,
				Name = "Julius Avery",
				Description = "Julius Avery is an Australian screenwriter and film director.",
				ImageUrl = "https://pics.filmaffinity.com/julius_avery-142054011329446-nm_large.jpg"
			};
			producers.Add(producer);

			return producers.ToArray();
		}
	}
}
