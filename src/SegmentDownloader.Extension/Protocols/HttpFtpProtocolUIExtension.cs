using System;
using System.Collections.Generic;
using System.Text;
using SegmentDownloader.Core.Extensions;
using System.Windows.Forms;
using SegmentDownloader.Extension.Protocols.UI;

namespace SegmentDownloader.Extension.Protocols
{
    public class HttpFtpProtocolUIExtension : IUIExtension
    {
        #region IUIExtension Members

        public System.Windows.Forms.Control[] CreateSettingsView()
        {
            return new Control[] { new Proxy() };
        }

        public void PersistSettings(System.Windows.Forms.Control[] settingsView)
        {
            Proxy proxy = (Proxy)settingsView[0];

            Settings.Default.UseProxy = proxy.UseProxy;
            Settings.Default.ProxyAddress = proxy.ProxyAddress;
            Settings.Default.ProxyPort = proxy.ProxyPort;
            Settings.Default.ProxyByPassOnLocal = proxy.ProxyByPassOnLocal;
            Settings.Default.ProxyUserName = proxy.ProxyUserName;
            Settings.Default.ProxyPassword = proxy.ProxyPassword;
            Settings.Default.ProxyDomain = proxy.ProxyDomain;
            Settings.Default.Save();
        }

        #endregion
    }
}
