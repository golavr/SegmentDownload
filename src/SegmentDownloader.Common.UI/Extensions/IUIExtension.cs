using System.Windows.Forms;

namespace SegmentDownloader.Common.UI.Extensions
{
    public interface IUIExtension
    {
        Control[] CreateSettingsView();

        void PersistSettings(Control[] settingsView);
    }
}
