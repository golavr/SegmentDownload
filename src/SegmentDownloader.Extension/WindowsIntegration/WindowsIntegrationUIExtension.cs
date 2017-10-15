using System;
using System.Collections.Generic;
using System.Text;
using SegmentDownloader.Common.UI.Extensions;
using SegmentDownloader.Core.Extensions;

namespace SegmentDownloader.Extension.WindowsIntegration
{
    public class WindowsIntegrationUIExtension : IUIExtension
    {
        #region IUIExtension Members

        public System.Windows.Forms.Control[] CreateSettingsView()
        {
            return new System.Windows.Forms.Control[] { new WindowsIntegrationUI() };
        }

        public void PersistSettings(System.Windows.Forms.Control[] settingsView)
        {
            WindowsIntegrationUI windowsIntegration = (WindowsIntegrationUI)settingsView[0];

            Settings.Default.MonitorClipboard = windowsIntegration.MonitorClipboard;
            Settings.Default.Save();

            WindowsStartupUtility.Register(windowsIntegration.StartWithWindows);
        }

        #endregion
    }
}
