using System;
using System.Collections.Generic;
using System.Text;
using SegmentDownloader.Core.Extensions;

namespace SegmentDownloader.Extension.WindowsIntegration
{
    public class WindowsIntegrationExtension: IExtension
    {
        #region IExtension Members

        public string Name
        {
            get { return ("Windows Integration"); }
        }

        public IUIExtension UIExtension
        {
            get { return new WindowsIntegrationUIExtension(); }
        }

        #endregion
    }
}
