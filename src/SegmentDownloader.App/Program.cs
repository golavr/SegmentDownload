using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SegmentDownloader.Core;
using System.Diagnostics;
using System.Windows.Forms;
using SegmentDownloader.App.UI;
using SegmentDownloader.Extension.Protocols;
using SegmentDownloader.Extension.Video;
using SegmentDownloader.Extension.Video.Impl;

namespace SegmentDownloader.App
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            App.Instance.Start(args);
        }
    }
}
