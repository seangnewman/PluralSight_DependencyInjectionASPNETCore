using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisBookings.Web.Configuration;

//namespace TennisBookings.Web.Core.DependencyInjection
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationServiceCollectionExtensioons
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config )
        {
            services.Configure<ExternalServicesConfig>(config.GetSection("ExternalServices"));
            services.Configure<DistributedCacheConfig>(config.GetSection("DistributedCache"));
            services.Configure<ClubConfiguration>(config.GetSection("ClubSettings"));
            services.Configure<BookingConfiguration>(config.GetSection("CourtBookings"));
            services.Configure<FeaturesConfiguration>(config.GetSection("Features"));
            services.Configure<MembershipConfiguration>(config.GetSection("Membership"));

            services.TryAddSingleton<IBookingConfiguration>(sp
                => sp.GetRequiredService<IOptions<BookingConfiguration>>().Value);

            services.TryAddSingleton<IClubConfiguration>(sp
                => sp.GetRequiredService<IOptions<ClubConfiguration>>().Value);

            return services;
        }
    }
}
