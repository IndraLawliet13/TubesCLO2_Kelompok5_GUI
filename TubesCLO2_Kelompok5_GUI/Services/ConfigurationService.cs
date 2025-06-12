using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesCLO2_Kelompok5_GUI.Services
{
    public class ConfigurationService
    {
        private readonly IConfiguration _configuration;
        private readonly string _defaultLanguage;
        private Dictionary<string, string> _messages; // Made non-readonly to allow reloading
        public string ApiBaseUrl { get; }
        private string _currentLanguage; // Added for dynamic language switching

        public ConfigurationService()
        {
            // Setup configuration provider
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // Cari appsettings.json di direktori output
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // DbC: Pastikan konfigurasi ter-load
            Debug.Assert(_configuration != null, "Configuration should not be null after build.");

            // Ambil URL API dari config
            ApiBaseUrl = _configuration.GetValue<string>("ApiConfig:BaseUrl") ?? "http://localhost:5000"; // DbC: Pastikan URL tidak kosong
            ArgumentException.ThrowIfNullOrWhiteSpace(ApiBaseUrl, nameof(ApiBaseUrl));
            Console.WriteLine($"API Base URL set to: {ApiBaseUrl}"); // Debugging info

            // Ambil bahasa default dan set bahasa saat ini
            _defaultLanguage = _configuration.GetValue<string>("AppConfig:DefaultLanguage") ?? "id";
            _currentLanguage = _defaultLanguage; // Initialize current language

            // Load messages untuk bahasa saat ini
            LoadMessages();
            Debug.Assert(_messages != null, $"Messages for language '{_currentLanguage}' could not be loaded.");
        }

        private void LoadMessages()
        {
            _messages = _configuration.GetSection($"AppConfig:Messages:{_currentLanguage}")
                                      .Get<Dictionary<string, string>>() ?? new Dictionary<string, string>();
        }

        public string GetMessage(string key, params object[] args)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key, nameof(key));
            if (_messages.TryGetValue(key, out var messageFormat))
            {
                return args.Length > 0 ? string.Format(messageFormat, args) : messageFormat;
            }
            Debug.WriteLine($"Warning: Message key '{key}' not found for language '{_currentLanguage}'.");
            return $"[{key} ({_currentLanguage})]"; // Indicate language in fallback
        }

        public void SetLanguage(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
            {
                languageCode = _defaultLanguage; // Fallback to default if empty
            }

            if (languageCode == "id" || languageCode == "en") // Basic validation
            {
                if (_currentLanguage != languageCode)
                {
                    _currentLanguage = languageCode;
                    LoadMessages(); // Reload messages for the new language
                    Console.WriteLine($"Language set to: {_currentLanguage}"); // For debugging
                    // Persisting to a file is skipped for this subtask
                }
            }
            else
            {
                Console.WriteLine($"Invalid language code: {languageCode}. Using current: {_currentLanguage}"); // For debugging
            }
        }

        public string GetCurrentLanguage()
        {
            return _currentLanguage;
        }

        // Optional: Method to get default language if needed elsewhere
        public string GetDefaultLanguage()
        {
            return _defaultLanguage;
        }
    }
}