using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using MovieTickets.Data.EntityModels;

using System.Reflection;

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
	}
}
