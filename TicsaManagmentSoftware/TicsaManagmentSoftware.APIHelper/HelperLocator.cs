using Microsoft.Extensions.DependencyInjection;
using TicsaManagmentSoftware.APIHelper.Services;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.APIHelper {
    public static class HelperLocator {
        public static void AddTicsaServices(this IServiceCollection services, HelperConfig config) {
            services.AddSingleton(config);
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICommentaryService, CommentaryService>();
            services.AddScoped<IGammeService, GammeService>();
            services.AddScoped<IGammeTypeService, GammeTypeService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderContentService, OrderContentService>();
            services.AddScoped<IProducerService, ProducerService>();
        }
    }
}
