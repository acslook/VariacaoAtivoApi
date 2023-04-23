using VariacaoAtivoApi.Acl;
using VariacaoAtivoApi.Application.Services;
using VariacaoAtivoApi.Data.Configuration;
using VariacaoAtivoApi.Domain.Interfaces.Acl;
using VariacaoAtivoApi.Domain.Interfaces.Repositories;
using VariacaoAtivoApi.Domain.Interfaces.Services;
using VariacaoAtivoApi.Repository.Repositories;

namespace VariacaoAtivoApi.DI
{
    public static class ConfigurationDI
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IFinanceYahooIntegrationService, FinanceYahooIntegrationService>();
            services.AddTransient<IAtivoFinanceiroService, AtivoFinanceiroService>();
            services.AddHttpClient<IFinanceYahooAcl, FinanceYahooAcl>();
            services.AddScoped<IVariacaoAtivoRepository, VariacaoAtivoRepository>();
            
            return services;
        }
    }
}
