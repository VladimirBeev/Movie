namespace MovieTickets.Common
{
	public static class EntityValidationConstant
	{
		public static class ActorConstants
		{
			public const int ActorNameMinLength = 0;
			public const int ActorNameMaxLength = 200;

			public const int ActorDescriptionMinLength = 20;
			public const int ActorDescriptionMaxLength = 2000;

			public const int ActorImageUrlMaxLength = 2048;
		}

		public static class ProducerConstants
		{
			public const int ProducerNameMinLength = 0;
			public const int ProducerNameMaxLength = 200;

			public const int ProducerDescriptionMinLength = 20;
			public const int ProducerDescriptionMaxLength = 2000;
		}

		public static class CinemaConstants
		{
			public const int CinemaNameMinLength = 0;
			public const int CinemaNameMaxLength = 200;

			public const int CinemaDescriptionMinLength = 20;
			public const int CinemaDescriptionMaxLength = 2000;

			public const int CinemaCountryMinLength = 0;
			public const int CinemaCountryMaxLength = 100;

			public const int CinemaCityMinLength = 0;
			public const int CinemaCityMaxLength = 100;

			public const int CinemaStreetMinLength = 0;
			public const int CinemaStreetMaxLength = 100;

			public const int CinemaLogoUrlMaxLength = 2048;
		}

		public static class MovieConstants
		{
			public const int MovieTitleMinLength = 0;
			public const int MovieTitleMaxLength = 200;

			public const int MovieDescriptionMinLength = 0;
			public const int MovieDescriptionMaxLength = 2000;

			public const int MovieCategoryMinLength = 1;
			public const int MovieCategoryMaxLength = 10;

			public const string MoviePriceMinValue = "0";
			public const string MoviePriceMaxValue = "100";

			public const int MovieImageUrlMaxLength = 2048;
		}
	}
}
