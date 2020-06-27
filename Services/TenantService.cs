using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace FluentMigratorDemo.Services
{
    public class TenantService: ITenantService {
        private readonly IServiceProvider _provider;
        public TenantService(IServiceProvider provider) {
            _provider = provider;
        }

        public void Create(string tenantName) {
            using(var scope = _provider.CreateScope())
            {
                var migrationRunner = scope.ServiceProvider.GetService<IMigrationRunner>();
                migrationRunner.MigrateUp();
            }
        }
    }
}