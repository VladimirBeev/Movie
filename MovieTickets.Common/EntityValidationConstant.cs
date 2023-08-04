namespace MovieTickets.Common
{
	public static class EntityValidationConstant
	{
		public static class ActorConstants
		{
			public const int ActorNameMinLength = 3;
			public const int ActorNameMaxLength = 200;

			public const int ActorDescriptionMinLength = 20;
			public const int ActorDescriptionMaxLength = 2000;

			public const int ActorImageUrlMaxLength = 2048;
		}

		public static class ProducerConstants
		{
			public const int ProducerNameMinLength = 3;
			public const int ProducerNameMaxLength = 200;

			public const int ProducerDescriptionMinLength = 20;
			public const int ProducerDescriptionMaxLength = 2000;

			public const int ProducerImageUrlMaxLength = 2048;
		}

		public static class CinemaConstants
		{
			public const int CinemaNameMinLength = 3;
			public const int CinemaNameMaxLength = 200;

			public const int CinemaDescriptionMinLength = 20;
			public const int CinemaDescriptionMaxLength = 2000;

			public const int CinemaCountryMinLength = 3;
			public const int CinemaCountryMaxLength = 100;

			public const int CinemaCityMinLength = 3;
			public const int CinemaCityMaxLength = 100;

			public const int CinemaStreetMinLength = 3;
			public const int CinemaStreetMaxLength = 100;

			public const int CinemaLogoUrlMaxLength = 2048;
		}

		public static class MovieConstants
		{
			public const int MovieTitleMinLength = 3;
			public const int MovieTitleMaxLength = 200;

			public const int MovieDescriptionMinLength = 3;
			public const int MovieDescriptionMaxLength = 2000;

			public const int MovieCategoryMinLength = 1;
			public const int MovieCategoryMaxLength = 10;

			public const string MoviePriceMinValue = "0";
			public const string MoviePriceMaxValue = "100";

			public const int MovieImageUrlMaxLength = 2048;
		}

		public static class OrderConstant
		{
			public const int OrderEmailMinLength = 3;
			public const int OrderEmailMaxLength = 50;
		}

		public static class UserConstant
		{
			public const int FirstNameMinLength = 1;
			public const int FirstNameMaxLength = 30;
        }
	}
}
