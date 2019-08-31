using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SegmentDownloader.SampleNetStandard;

namespace SegmentDownloader.SampleNet
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
