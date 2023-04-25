using System.Security.Cryptography.X509Certificates;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;

using Microsoft.Extensions.DependencyInjection;


namespace CRUD
{
    public static class Program
    {
        private static string stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;
        public static FormularioListagem listagem = new FormularioListagem();

        [STAThread]
        static void Main()
        {
            Application.Run(listagem);
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
                    .WithGlobalConnectionString(stringConexao)
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