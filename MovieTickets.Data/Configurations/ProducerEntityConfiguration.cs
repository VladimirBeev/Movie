using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTickets.Data.EntityModels;

namespace MovieTickets.Data.Configurations
{
	public class ProducerEntityConfiguration : IEntityTypeConfiguration<Producer>
	{
		public void Configure(EntityTypeBuilder<Producer> builder)
		{
			//builder.HasData(GenerateProducers());
		}

		private Producer[] GenerateProducers()
		{
			ICollection<Producer> producers = new List<Producer>();

			Producer producer;

			producer = new Producer()
			{
				Id = 1,
				Name = "Producer 1",
				Description = "This is the description of the first Producer",
				ImageUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"
			};
			producers.Add(producer);

			producer = new Producer()
			{
				Id = 2,
				Name = "Producer 2",
				Description = "This is the description of the Second Producer",
				ImageUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
			};
			producers.Add(producer);


			producer = new Producer()
			{
				Id = 3,
				Name = "Producer 3",
				Description = "This is the description of the thurd Producer",
				ImageUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
			};
			producers.Add(producer);

			producer = new Producer()
			{
				Id = 4,
				Name = "Producer 4",
				Description = "This is the description of the forth Producer",
				ImageUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
			};
			producers.Add(producer);

			producer = new Producer()
			{
				Id = 5,
				Name = "Producer 5",
				Description = "This is the description of the fifth Producer",
				ImageUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
			};
			producers.Add(producer);

			return producers.ToArray();
		}
	}
}
