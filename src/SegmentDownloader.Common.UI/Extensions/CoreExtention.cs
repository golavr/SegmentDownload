namespace SegmentDownloader.Common.UI.Extensions
{
    public class CoreExtention : IExtension
    {
        #region IExtension Members

        public string Name
        {
            get { return "Core"; }
        }

        public IUIExtension UIExtension
        {
            get { return new CoreUIExtention(); }
        }

        #endregion
    }
}
