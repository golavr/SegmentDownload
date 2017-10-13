using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SegmentDownloader.Extension.AutoDownloads;
using SegmentDownloader.Extension.AutoDownloads.UI;

namespace SegmentDownloader.Spider.UI
{
    public partial class StartAutoDownloadsForm : Form
    {
        public StartAutoDownloadsForm()
        {
            InitializeComponent();
        }

        public ScheduledDownloadEnabler ScheduledDownloadEnabler
        {
            get
            {
                return scheduledDownloadEnabler1;
            }
        }
    }
}