using System;
using System.Collections.Generic;
using System.Text;
using SegmentDownloader.Core;

namespace SegmentDownloader.Core.Extensions
{
    public interface IExtension
    {
        string Name { get; }

        IUIExtension UIExtension { get; }
    }
}
