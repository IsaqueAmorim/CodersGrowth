using System.Security.Cryptography.X509Certificates;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;

using Microsoft.Extensions.DependencyInjection;


namespace CRUD
{
    public static class Program
    {
        private static string stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoMeuPC"].ConnectionString;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static FormularioListagem listagem = new FormularioListagem();

        [STAThread]
        static void Main()
        {

           

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //var sc = new ServiceCollection()
            //  .AddFluentMigratorCore()
            //  .ConfigureRunner(rb => rb
            //  .AddSqlServer()
            //  .WithGlobalConnectionString(stringConexao)
            //  .ScanIn(typeof(JogadoresMigration).Assembly)
            //  .For.Migrations())
            //  .AddLogging(lb => lb.AddFluentMigratorConsole())
            //  .BuildServiceProvider(false);

            //using (var scope = sc.CreateScope())
            //{
            //    UpdateDatabase(scope.ServiceProvider);
            //}

            //static void UpdateDatabase(IServiceProvider service)
            //{
            //    var runner = service.GetRequiredService<IMigrationRunner>();
            //    if (runner.HasMigrationsToApplyUp())
            //    {
            //        runner.ListMigrations();
            //        runner.MigrateUp();
            //    }
            //}
            Application.Run(listagem);
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                // Put the database update into a scope to ensure
                // that all resources will be disposed.
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static ServiceProvider CreateServices()
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(stringConexao)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(JogadoresMigration).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }



    }
    
}