using System;
using System.Collections.Generic;
using System.Text;
using SegmentDownloader.Core.Extensions;
using SegmentDownloader.Core;
using SegmentDownloader.Extension.Notifications.Helpers;

namespace SegmentDownloader.Extension.Notifications
{
    public class NotificationsExtension: IExtension
    {
        #region IExtension Members

        public string Name
        {
            get { return "Notifications"; }
        }

        public IUIExtension UIExtension
        {
            get { return new NotificationsUIExtension(); }
        }

        #endregion

        #region Constructor

        public NotificationsExtension(INotificationsExtensionParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            SoundHelper.Start(parameters);
            BalloonHelper.Start(parameters);
        }

        public NotificationsExtension():
            this(new NotificationsExtensionParametersSettingsProxy())
        {

        }
 
        #endregion
    }
}
