using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using SegmentDownloader.Core;
using SegmentDownloader.Protocol;

namespace SegmentDownloader.SampleCore
{
    class Program
    {
        private const string Url = "http://speedtest-ny.turnkeyinternet.net/100mb.bin";
        //private const string Url = "ftp://speedtest.tele2.net/50MB.zip";
        private const string LocalFolder = @"c:\temp";

        private static ManualResetEventSlim _manualResetEventSlim;

        static void Main(string[] args)
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

            _manualResetEventSlim = new ManualResetEventSlim();

            // start download
            downloader.Start();

            // wait till download completed
            _manualResetEventSlim.Wait();

            Console.WriteLine("Press Any Key To Exit");
            Console.ReadKey();
        }

        private static void SegmentChanged(object sender, SegmentEventArgs e)
        {
            var connecting = e.Downloader.Segments.Count(s => s.State == SegmentState.Connecting);
            var downloading = e.Downloader.Segments.Count(s => s.State == SegmentState.Downloading);
            var error = e.Downloader.Segments.Count(s => s.State == SegmentState.Error);
            var finished = e.Downloader.Segments.Count(s => s.State == SegmentState.Finished);

            Console.WriteLine($"Segments {nameof(connecting)}: {connecting}, {nameof(downloading)}: {downloading}, {nameof(error)}: {error}, {nameof(finished)}: {finished}");
        }

        private static void DownloadEnded(object sender, DownloaderEventArgs e)
        {
            Console.WriteLine(e.Downloader.State == DownloaderState.EndedWithError
                ? $"Download Ended With Error '{e.Downloader.LastError.Message}'"
                : "Download Ended");

            _manualResetEventSlim.Set();
        }

        private static void RegisterProtocols()
        {
            // register protocols
            ProtocolProviderFactory.RegisterProtocolHandler("http", typeof(HttpProtocolProvider));
            ProtocolProviderFactory.RegisterProtocolHandler("https", typeof(HttpProtocolProvider));
            ProtocolProviderFactory.RegisterProtocolHandler("ftp", typeof(FtpProtocolProvider));
        }
    }
}
