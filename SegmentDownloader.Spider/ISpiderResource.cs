using System;
using System.Collections.Generic;
using System.Text;
using SegmentDownloader.Core;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.IO;
using System.Threading;

namespace SegmentDownloader.Spider
{
    public interface ISpiderResource
    {
        string Location { get; }

        int Depth { get; }

        ISpiderResource ParentResource { get; }

        List<ISpiderResource> NextResources { get; }

        IAsyncRetriver BeginReceive();

        void EndReceive();
    }
}
