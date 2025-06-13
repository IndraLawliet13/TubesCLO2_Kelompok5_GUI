using System; // Required for STAThread
using System.Windows.Forms; // Required for Application, ApplicationConfiguration
using TubesCLO2_Kelompok5_GUI.Services;
using TubesCLO2_Kelompok5_GUI.Views; // Required for LoginForm

namespace TubesCLO2_Kelompok5_GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Create a single instance of ConfigurationService
            ConfigurationService configService = new ConfigurationService();

            // Pass it to LoginForm. LoginForm will create its own LoginController.
            Application.Run(new LoginForm(configService));
        }
    }
}