using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SegmentDownloader.Extension.WindowsIntegration.ClipboardMonitor
{
    public interface IClipboardDataHandler
    {
        void HandleClipboardData(IDataObject data);
    }
}
