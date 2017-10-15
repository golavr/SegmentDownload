using System;
using System.Windows.Forms;
using SegmentDownloader.Core;
using SegmentDownloader.Core.Common;

namespace SegmentDownloader.Common.UI
{
    public partial class DownloadFolder : UserControl
    {
        public DownloadFolder()
        {
            InitializeComponent();

            Text = "Directory";

            txtSaveTo.Text = Settings.Default.DownloadFolder;
        }

        public string LabelText
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }

        public string Folder
        {
            get { return PathHelper.GetWithBackslash(txtSaveTo.Text); }
        }

        private void btnSelAV_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSaveTo.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
