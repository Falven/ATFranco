/*
 * Copyright (c) Dapper Apps.  All rights reserved.
 * Use of this source code is subject to the terms of the Dapper Apps license 
 * agreement under which you licensed this sample source code and is provided AS-IS.
 * If you did not accept the terms of the license agreement, you are not authorized 
 * to use this sample source code.  For the terms of the license, please see the 
 * license agreement between you and Dapper Apps.
 *
 * To see the article about this app, visit http://www.dapper-apps.com/DapperToolkit
 */

namespace ATFranco.Models
{
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// The layer of classes that participate in the Property Notification system,
    /// and therefore use PropertyChanging and PropertyChanged notifications.
    /// </summary>
    public abstract class PropertyNotificationBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanging event for the specified property if there are any subscribers.
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing.</param>
        protected void OnPropertyChanging(string propertyName)
        {
            if (null != PropertyChanging)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event for the specified property if there are any subscribers.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
