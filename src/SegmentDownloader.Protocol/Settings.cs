using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SegmentDownloader.Protocol {
    
    public sealed class Settings
    {
        private const string ConfigFile = "appsettings.json";

        private static readonly Settings DefaultInstance;

        public static Settings Default => DefaultInstance;
        
        public string ProxyAddress { get; set; }

        public string ProxyUserName { get; set; }

        public string ProxyPassword { get; set; }

        public string ProxyDomain { get; set; }

        public bool UseProxy { get; set; } = false;

        public bool ProxyByPassOnLocal { get; set; } = true;

        public int ProxyPort { get; set; } = 80;

        static Settings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(ConfigFile);
            var configuration = configurationBuilder.Build();
            var configurationSection = configuration.GetSection(nameof(Protocol));
            DefaultInstance = configurationSection.Get<Settings>();
            if (DefaultInstance == null)
            {
                throw new JsonReaderException($"Missing {nameof(Protocol)} section in {ConfigFile} file");
            }
        }
    }
}
