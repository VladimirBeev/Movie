using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using MovieTickets.Data.EntityModels;

using System.Reflection;

using static MovieTickets.Common.UserRoles;
using static MovieTickets.Common.AdminUser;
using MovieTickets.Common;

namespace MovieTickets.Web.Infrastructure.Extensions
{
	public static class WebApplicationBuilderExtensions
	{
		/// <summary>
		/// This method registert all services with their interfaces and implementations of given assembly.
		/// The assembly is taken from the type of random service implementation provided.
		/// </summary>
		/// <param name="services"></param>
		/// <param name="serviceType">Type of random service implementation</param>
		/// <exception cref="InvalidOperationException"></exception>
		public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
		{
			Assembly? serivceAssembly = Assembly.GetAssembly(serviceType);

			if (serivceAssembly == null)
			{
				throw new InvalidOperationException("Invalid service type provided");
			}

			Type[] serviceTypes = serivceAssembly.GetTypes()
				.Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
				.ToArray();

			foreach (Type implementationType in serviceTypes)
			{
				Type? interfaceType = implementationType.GetInterface($"I{implementationType.Name}");

				if (interfaceType == null)
				{
					throw new InvalidOperationException($"No Interface is provided for the service with name: {implementationType.Name}");
				}

				services.AddScoped(interfaceType, implementationType);
			}
		}

		public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
		{
			using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

			IServiceProvider serviceProvider = scopedServices.ServiceProvider;

			UserManager<ApplicationUser> userManager =
				serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			RoleManager<IdentityRole<Guid>> roleManager =
				serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

			Task.Run(async () =>
			{
				if (await roleManager.RoleExistsAsync(UserRoles.Admin))
				{
					return;
				}

				IdentityRole<Guid> role =
					new IdentityRole<Guid>(UserRoles.Admin);

				await roleManager.CreateAsync(role);

				ApplicationUser adminUser =
					await userManager.FindByEmailAsync(email);

				if (adminUser == null)
				{
					var newAdminUser = new ApplicationUser()
					{
						FullName = AdminUser.FullName,
						UserName = AdminUser.FullName,
						EmailConfirmed = true,
						Email = AdminUser.Email,
					};

					await userManager.CreateAsync(newAdminUser, "admin");
					await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
				}
			})
			.GetAwaiter()
			.GetResult();

			return app;
		}
	}
}
