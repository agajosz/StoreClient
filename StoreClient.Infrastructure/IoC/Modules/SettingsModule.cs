using Autofac;
using Microsoft.Extensions.Configuration;
using StoreClient.Infrastructure.Data;
using StoreClient.Infrastructure.Extensions;

namespace StoreClient.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<SqlSettings>())
                .SingleInstance();
        }
    }
}
