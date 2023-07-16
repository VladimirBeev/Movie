using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTickets.Common
{
	public static class EntityValidationConstant
	{
		public static class ActorConstants
		{
			public const int ActorNameMinLength = 0;
			public const int ActorNameMaxLength = 200;

			public const int ActorDescriptionMinLength = 0;
			public const int ActorDescriptionMaxLength = 2000;
		}

		public static class ProducerConstants
		{
			public const int ProducerNameMinLength = 0;
			public const int ProducerNameMaxLength = 200;

			public const int ProducerDescriptionMinLength = 0;
			public const int ProducerDescriptionMaxLength = 2000;
		}

		public static class CinemaConstants
		{
			public const int CinemaNameMinLength = 0;
			public const int CinemaNameMaxLength = 200;

			public const int CinemaDescriptionMinLength = 0;
			public const int CinemaDescriptionMaxLength = 2000;

			public const int CinemaCountryMinLength = 0;
			public const int CinemaCountryMaxLength = 100;

			public const int CinemaCityMinLength = 0;
			public const int CinemaCityMaxLength = 100;

			public const int CinemaStreetMinLength = 0;
			public const int CinemaStreetMaxLength = 100;
		}

		public static class MovieConstants
		{
			public const int MovieNameMinLength = 0;
			public const int MovieNameMaxLength = 200;

			public const int MovieDescriptionMinLength = 0;
			public const int MovieDescriptionMaxLength = 2000;

			public const int MovieCategoryMinLength = 1;
			public const int MovieCategoryMaxLength = 10;
		}
	}
}
