using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SegmentDownloader.Core
{
    public sealed class Settings
    {
        private const string ConfigFile = "appsettings.json";

        private static readonly Settings DefaultInstance;

        public static Settings Default => DefaultInstance;

        public long MinSegmentSize { get; set; } = 200000;

        public int MinSegmentLeftToStartNewSegment { get; set; } = 30;

        public int InitialRetryDelay { get; set; } = 5;

        public int InitialMaxRetries { get; set; } = 5;

        public int RetryDelay { get; set; } = 5;

        public int MaxRetries { get; set; } = 10;

        public int MaxSegments { get; set; } = 5;

        public string DownloadFolder { get; set; }

        static Settings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(ConfigFile);
            var configuration = configurationBuilder.Build();
            var configurationSection = configuration.GetSection(nameof(Core));
            DefaultInstance = configurationSection.Get<Settings>();
            if (DefaultInstance == null)
            {
                throw new JsonReaderException($"Missing {nameof(Core)} section in {ConfigFile} file");
            }
        }
    }
}
