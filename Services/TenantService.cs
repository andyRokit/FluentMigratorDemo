using System;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Conventions;
using FluentMigrator.Runner.Initialization;
using FluentMigratorDemo.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace FluentMigratorDemo.Services
{
    public class TenantService : ITenantService
    {
        private readonly IServiceProvider _provider;
        public TenantService(IServiceProvider provider)
        {
            _provider = provider;
        }


        public void Create(string tenantName)
        {

            var serviceProvider = new ServiceCollection()
                            .AddSingleton<IConventionSet>(new DefaultConventionSet(tenantName, null))
                            .AddFluentMigratorCore()
                            .ConfigureRunner(r => r.AddPostgres()
                                                    .WithGlobalConnectionString("Host=localhost;Database=fluentmigrator;Username=postgres;Password=admin")
                                                    .WithRunnerConventions(new MigrationRunnerConventions()
                                                    {

                                                    })
                                                    .ScanIn(typeof(AddSecuritySchema).Assembly).For.Migrations()
                            )
                            .Configure<RunnerOptions>(opt =>
                            {
                                opt.TransactionPerSession = true;
                            })
                            .BuildServiceProvider(false);

            using (var scope = serviceProvider.CreateScope())
            {
                var migrationRunner = scope.ServiceProvider.GetService<IMigrationRunner>();
                migrationRunner.MigrateUp();
            }
        }
    }
}