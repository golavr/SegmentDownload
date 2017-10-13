using System;
using System.Collections.Generic;
using System.Text;
using SegmentDownloader.Core.Extensions;

namespace SegmentDownloader.Core.UI
{
    public class CoreExtention : IExtension
    {
        #region IExtension Members

        public string Name
        {
            get { return "Core"; }
        }

        public IUIExtension UIExtension
        {
            get { return new CoreUIExtention(); }
        }

        #endregion
    }
}
