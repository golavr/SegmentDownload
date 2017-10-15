using System;
using System.Collections.Generic;
using System.Text;
using SegmentDownloader.Common.UI.Extensions;
using SegmentDownloader.Core.Extensions;

namespace SegmentDownloader.Extension.SpeedLimit
{
    public interface ISpeedLimitParameters: IExtensionParameters
    {
        bool Enabled { get; set; }

        double MaxRate { get; set; }
    }
}
