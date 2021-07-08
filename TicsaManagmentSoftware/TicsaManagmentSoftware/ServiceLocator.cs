using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using TicsaManagmentSoftware.APIHelper;

namespace TicsaManagmentSoftware {
    public static class ServiceLocator {
        public static void Locate(this IServiceCollection services) {
            IConfiguration configuration = BuildConfig(new HostingEnvironment());
            services.AddTicsaServices(new HelperConfig() {
                AuthKey = configuration.GetValue<string>("AuthKey"),
                UrlApi = configuration.GetValue<string>("UrlApi")
            });
        }
        private static IConfiguration BuildConfig(IHostingEnvironment env) {
            return new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables().Build();
        }
    }
}
