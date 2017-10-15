using System.ComponentModel;

namespace SegmentDownloader.Common.UI.Extensions
{
    public interface IExtensionParameters
    {
        event PropertyChangedEventHandler ParameterChanged;
    }
}
