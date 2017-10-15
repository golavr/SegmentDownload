using System;
using System.Windows.Forms;
using SegmentDownloader.Core;
using SegmentDownloader.Core.Common;

namespace SegmentDownloader.Common.UI
{
    public partial class Connection : UserControl
    {
        public Connection()
        {
            Text = "Connection";
            InitializeComponent();

            numRetryDelay.Value = Settings.Default.RetryDelay;
            numMaxRetries.Value = Settings.Default.MaxRetries;
            numMinSegSize.Value = Settings.Default.MinSegmentSize;
            numMaxSegments.Value = Settings.Default.MaxSegments;

            UpdateControls();
        }

        public int RetryDelay
        {
            get
            {
                return (int)numRetryDelay.Value;
            }
        }

        public int MaxRetries
        {
            get
            {
                return (int)numMaxRetries.Value;
            }
        }

        public long MinSegmentSize
        {
            get
            {
                return (long)numMinSegSize.Value;
            }
        }

        public int MaxSegments
        {
            get
            {
                return (int)numMaxSegments.Value;
            }
        }

        private void numMinSegSize_ValueChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void UpdateControls()
        {
            lblMinSize.Text = ByteFormatter.ToString((long)numMinSegSize.Value);
        }
    }
}
