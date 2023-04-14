using System.Security.Cryptography.X509Certificates;

namespace CRUD
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static FML_Listagem listagem = new FML_Listagem();
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(listagem);
        }
    }
}