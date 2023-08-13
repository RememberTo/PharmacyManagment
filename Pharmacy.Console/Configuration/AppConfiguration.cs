using System.Text.Json;

namespace Pharmacy.Console.Configuration
{
    public class AppConfiguration
    {
        private record ConfigData(string DbConnection);

        private const string ConfigFilePath = "Configuration/settings.json";
        private readonly ConfigData? _configData;

        public AppConfiguration()
        {
            var configJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFilePath));
            _configData = JsonSerializer.Deserialize<ConfigData>(configJson);

        }
        public string this[string key]
        {
            get
            {
                var propertyInfo = _configData?.GetType().GetProperty(key);
                if (propertyInfo == null) throw new ArgumentException($"Key '{key}' not found in settings.json");
                
                return propertyInfo.GetValue(_configData)?.ToString() ?? string.Empty;
            }
        }
    }
}
