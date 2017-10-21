using System;
using SegmentDownloader.Common.UI.Extensions;
using SegmentDownloader.Core;
using SegmentDownloader.Protocol;

namespace SegmentDownloader.Extension.Protocols
{
    public class HttpFtpProtocolExtension: IExtension
    {
        #region IExtension Members

        public string Name
        {
            get { return "HTTP/FTP"; }
        }

        public IUIExtension UIExtension
        {
            get { return new HttpFtpProtocolUIExtension(); }
        }

        public HttpFtpProtocolExtension()
        {
            ProtocolProviderFactory.RegisterProtocolHandler("http", typeof(HttpProtocolProvider));
            ProtocolProviderFactory.RegisterProtocolHandler("https", typeof(HttpProtocolProvider));
            ProtocolProviderFactory.RegisterProtocolHandler("ftp", typeof(FtpProtocolProvider));
        }

        #endregion
    }
}
