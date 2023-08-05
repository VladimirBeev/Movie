using System.Security.Claims;

namespace MovieTickets.Web.Infrastructure.Extensions
{
	public static class ClaimsPrincipalExtensions
	{
		public static string Id(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}

		public static string Role(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.Role);
		}

		public static string Email(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.Email);
		}
	}
}
