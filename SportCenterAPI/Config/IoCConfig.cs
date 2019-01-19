using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SportCenterAPI.Models.Manager;

namespace SportCenterAPI.Config
{
    /// <summary>
    /// Allow to register dependency injection
    /// </summary>
    public static class IoCConfig
    {
        /// <summary>
        /// Add the dependency injection for the App
        /// </summary>
        /// <param name="services">The list of the app services</param>
        /// <returns>The list of the services updated</returns>
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddTransient<ISportManager, SportManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IMemberManager, MemberManager>();
            services.AddTransient<ICourtManager, CourtManager>();
            services.AddTransient<IBookingManager, BookingManager>();

            return services;
        }
    }
}
