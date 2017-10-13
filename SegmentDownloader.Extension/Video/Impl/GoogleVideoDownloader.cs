using System;
using System.Collections.Generic;
using System.Text;
using SegmentDownloader.Extension.Protocols;
using SegmentDownloader.Core;
using System.IO;
using System.Net;
using System.Web;

namespace SegmentDownloader.Extension.Video.Impl
{
    public class GoogleVideoDownloader : BaseVideoDownloader
    {
        public const string SiteName = "Google Video";

        //http://video.google.com/videoplay?docid=6527966434248029824
        //http://video.google.com/videoplay?docid=-3840236067834151894
        public const string UrlPattern = @"(?:[Vv][Ii][Dd][Ee][Oo]\.[Gg][Oo][Oo][Gg][Ll][Ee]\.[Cc][Oo][Mm]/videoplay\?docid=)-?(\w[\w|-]*)";

        protected override ResourceLocation ResolveVideoURL(string url, string pageData,
            out string videoTitle)
        {
            videoTitle = TextUtil.JustAfter(pageData, "<title>", "</title>");

            url = TextUtil.JustAfter(pageData, "src=\"/googleplayer.swf?&videoUrl=", "&thumbnailUrl=");

            return ResourceLocation.FromURL(HttpUtility.UrlDecode(url));
        }
    }
}
