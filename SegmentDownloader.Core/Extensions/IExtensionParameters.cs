using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace SegmentDownloader.Core.Extensions
{
    public interface IExtensionParameters
    {
        event PropertyChangedEventHandler ParameterChanged;
    }
}
