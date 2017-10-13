using System;
using System.Collections.Generic;
using System.Text;

namespace SegmentDownloader.Spider
{
    public interface ISpiderResourceFactory
    {
        ISpiderResource CreateSpider(SpiderContext cntx, ISpiderResource parent, string location);
    }
}
