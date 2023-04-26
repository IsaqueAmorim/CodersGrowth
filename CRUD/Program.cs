using System.Security.Cryptography.X509Certificates;
using CRUD.Repositorios;
using CRUD.Servicos;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CRUD
{
    public static class Program
    {
       
        [STAThread]
        static void Main()
        {
            var builder = CriarHostBuilder();
            var provedorServicos = builder.Build().Services;
            var repositorio = provedorServicos.GetService<IRepositorioJogadores>();
          
           
            Application.Run(new FormularioListagem(repositorio));
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

     
        static ServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString("ConexaoDB")
                    .ScanIn(typeof(_20230424145100_JogadoresMigration).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        
        static void UpdateDatabase(IServiceProvider serviceProvider)
        {      
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        static IHostBuilder CriarHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((_context, services) =>
                {
                    services.AddScoped<IRepositorioJogadores, RepositorioJogadoresBD>();
                    services.AddScoped<Validacao>();
                });
        }


    }
    
}