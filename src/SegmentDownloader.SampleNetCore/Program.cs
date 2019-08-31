using System;
using SegmentDownloader.SampleNetStandard;

namespace SegmentDownloader.SampleNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleDownloader = new SampleDownloader();
            sampleDownloader.Start();
        }
    }
}
