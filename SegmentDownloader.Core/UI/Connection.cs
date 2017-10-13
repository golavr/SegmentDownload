using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SegmentDownloader.Core.Common;

namespace SegmentDownloader.Core.UI
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
            lblMinSize.Text = ByteFormatter.ToString((int)numMinSegSize.Value);
        }
    }
}
