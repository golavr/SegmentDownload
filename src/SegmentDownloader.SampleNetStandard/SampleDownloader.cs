using System;
using System.IO;
using System.Linq;
using System.Threading;
using SegmentDownloader.Core;
using SegmentDownloader.Protocol;

namespace SegmentDownloader.SampleNetStandard
{
    public class SampleDownloader
    {
        private const string Url = "http://speedtest-ny.turnkeyinternet.net/100mb.bin";
        //private const string Url = "ftp://speedtest.tele2.net/50MB.zip";
        private const string LocalFolder = @"c:\temp";

        private ManualResetEventSlim _manualResetEventSlim;
        private readonly Downloader _downloader;

        public SampleDownloader()
        {
            RegisterProtocols();

            var resourceLocation = ResourceLocation.FromURL(Url);

            // local file path
            var uri = new Uri(Url);
            var fileName = uri.Segments.Last();
            var localFilePath = Path.Combine(LocalFolder, fileName);

            // register download ended event
            DownloadManager.Instance.DownloadEnded += DownloadEnded;

            // create downloader with 8 segments
            var downloader = DownloadManager.Instance.Add(resourceLocation, null, localFilePath, 8, false);
            downloader.SegmentStarted += SegmentChanged;
            downloader.SegmentFailed += SegmentChanged;
            downloader.SegmentStoped += SegmentChanged;

            _downloader = downloader;
        }

        public void Start()
        {
            _manualResetEventSlim = new ManualResetEventSlim();

            // start download
            _downloader.Start();

            // wait till download completed
            _manualResetEventSlim.Wait();

            Console.WriteLine("Press Any Key To Exit");
            Console.ReadKey();
        }

        private void SegmentChanged(object sender, SegmentEventArgs e)
        {
            var connecting = e.Downloader.Segments.Count(s => s.State == SegmentState.Connecting);
            var downloading = e.Downloader.Segments.Count(s => s.State == SegmentState.Downloading);
            var error = e.Downloader.Segments.Count(s => s.State == SegmentState.Error);
            var finished = e.Downloader.Segments.Count(s => s.State == SegmentState.Finished);

            var transferred = e.Downloader.Transfered / 1024.0 / 1024.0;

            Console.WriteLine($"Transferred: {transferred:F}MB Segments {nameof(connecting)}: {connecting}, {nameof(downloading)}: {downloading}, {nameof(error)}: {error}, {nameof(finished)}: {finished}");
        }

        private void DownloadEnded(object sender, DownloaderEventArgs e)
        {
            Console.WriteLine(e.Downloader.State == DownloaderState.EndedWithError
                ? $"Download Ended With Error '{e.Downloader.LastError.Message}'"
                : "Download Ended");

            _manualResetEventSlim.Set();
        }

        private void RegisterProtocols()
        {
            // register protocols
            ProtocolProviderFactory.RegisterProtocolHandler("http", typeof(HttpProtocolProvider));
            ProtocolProviderFactory.RegisterProtocolHandler("https", typeof(HttpProtocolProvider));
            ProtocolProviderFactory.RegisterProtocolHandler("ftp", typeof(FtpProtocolProvider));
        }
    }
}
