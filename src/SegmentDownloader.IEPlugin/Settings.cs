using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace SegmentDownloader.IEPlugin
{
    internal static class Settings
    {
        private const string ROOTREG = "SOFTWARE\\SegmentDownloader";

        public static string SegmentDownloaderPath
        {
            get
            {
                return GetValue("SegmentDownloaderPath");
            }
        }

        private static string GetValue(string Key)
        {
            using (RegistryKey RKey = Registry.LocalMachine.CreateSubKey(ROOTREG))
            {
                return RKey.GetValue(Key, "").ToString();
            }
        }
    }
}
