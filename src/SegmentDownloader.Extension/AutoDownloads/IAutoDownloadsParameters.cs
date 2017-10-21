using System;
using System.Collections.Generic;
using System.Text;
using SegmentDownloader.Common.UI.Extensions;
using SegmentDownloader.Core.Extensions;

namespace SegmentDownloader.Extension.AutoDownloads
{
    public interface IAutoDownloadsParameters : IExtensionParameters
    {
        int MaxJobs { get; set; }

        bool WorkOnlyOnSpecifiedTimes { get; set; }

        string TimesToWork { get; set; }

        double MaxRateOnTime { get; set; }

        bool AutoStart { get; set; }
    }
}