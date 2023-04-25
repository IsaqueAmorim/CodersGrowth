using System.Security.Cryptography.X509Certificates;
using CRUD.Repositorios;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;


namespace CRUD
{
    public static class Program
    {
       
        [STAThread]
        static void Main()
        {
          
            var repositorio = new RepositorioJogadoresBD();
            Application.Run(new FormularioListagem(repositorio));
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

     
        private static ServiceProvider CreateServices()
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

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {      
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }



    }
    
}