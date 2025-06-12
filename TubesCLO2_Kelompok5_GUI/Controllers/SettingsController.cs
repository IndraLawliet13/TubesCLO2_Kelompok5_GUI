using TubesCLO2_Kelompok5_GUI.Services;

namespace TubesCLO2_Kelompok5_GUI.Controllers
{
    public class SettingsController
    {
        private readonly ConfigurationService _configService;

        public SettingsController()
        {
            _configService = new ConfigurationService();
        }

        public string GetCurrentLanguage()
        {
            return _configService.GetLanguage();
        }

        public void SaveLanguage(string lang)
        {
            _configService.SetLanguage(lang);
        }
    }
}