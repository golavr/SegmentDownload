using System;
using System.Collections.Generic;
using System.Text;

namespace SegmentDownloader.Spider
{
    public interface IAsyncRetriver
    {
        ISpiderResource Resource { get; }

        bool IsCompleted { get; }
    }
}
