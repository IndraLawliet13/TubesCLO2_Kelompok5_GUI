using TubesCLO2_Kelompok5_GUI.Models;
using TubesCLO2_Kelompok5_GUI.Services;

namespace TubesCLO2_Kelompok5_GUI.Controllers
{
    public class LoginController
    {
        private readonly User _staticUser = new User { Username = "admin", Password = "password" };
        private ConfigurationService _configService;
        public MainController MainController { get; private set; }


        public LoginController(ConfigurationService configService)
        {
            _configService = configService;
            // MainController now requires ConfigurationService in its constructor too.
            // This was handled in a previous step for MainController itself.
            MainController = new MainController(_configService);
        }

        public bool ValidateLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            // Login logic remains simple, no localized messages from here for now
            return username == _staticUser.Username && password == _staticUser.Password;
        }
    }
}
