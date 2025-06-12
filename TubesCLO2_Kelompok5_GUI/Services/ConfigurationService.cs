using Microsoft.Extensions.Configuration;

public class ConfigurationService
{
    private readonly IConfiguration _configuration;
    private string _currentLanguage;
    private Dictionary<string, string> _messages;

    public string ApiBaseUrl { get; }

    public ConfigurationService()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        ApiBaseUrl = _configuration.GetValue<string>("ApiConfig:BaseUrl") ?? "http://localhost:5000";

        _currentLanguage = _configuration.GetValue<string>("AppConfig:DefaultLanguage") ?? "id";
        LoadMessages(_currentLanguage);
    }

    private void LoadMessages(string language)
    {
        _messages = _configuration.GetSection($"AppConfig:Messages:{language}")
                                  .Get<Dictionary<string, string>>() ?? new Dictionary<string, string>();
    }

    public string GetMessage(string key, params object[] args)
    {
        if (_messages.TryGetValue(key, out var messageFormat))
        {
            return args.Length > 0 ? string.Format(messageFormat, args) : messageFormat;
        }
        return $"[{key}]";
    }

    public string GetLanguage()
    {
        return _currentLanguage;
    }

    public void SetLanguage(string lang)
    {
        _currentLanguage = lang;
        LoadMessages(lang);
    }
}
