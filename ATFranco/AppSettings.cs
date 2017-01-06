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

namespace ATFranco
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO.IsolatedStorage;

    /// <summary>
    /// TODO
    /// </summary>
    public class AppSettings : SingletonBase<AppSettings>, INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        private static IsolatedStorageSettings _isolatedStore;

        private const string WifiOnlySettingKeyName = "WifiOnlySetting";
        private const string FirstLaunchSettingKeyName = "InitialLaunchSetting";
        private const string LastUpdatedSettingKeyName = "LastUpdatedSetting";

        private const bool WifiOnlySettingDefault = false;
        private const bool FirstLaunchSettingDefault = true;
        private DateTime LastUpdatedSettingDefault = DateTime.Now;

        /// <summary>
        /// Constructor that gets the application settings.
        /// </summary>
        public AppSettings()
        {
            _isolatedStore = IsolatedStorageSettings.ApplicationSettings;
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (_isolatedStore.Contains(Key))
            {
                // If the value has changed
                if (_isolatedStore[Key] != value)
                {
                    // Store the new value
                    _isolatedStore[Key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                _isolatedStore.Add(Key, value);
                valueChanged = true;
            }

            return valueChanged;
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;

            // If the key exists, retrieve the value.
            if (_isolatedStore.Contains(Key))
            {
                value = (T)_isolatedStore[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }

            return value;
        }

        /// <summary>
        /// Property for allowing downloading of feeds only through WiFi
        /// </summary>
        public bool WifiOnly
        {
            get { return GetValueOrDefault<bool>(WifiOnlySettingKeyName, WifiOnlySettingDefault); }
            set { AddOrUpdateValue(WifiOnlySettingKeyName, value); }
        }

        /// <summary>
        /// Setting that determines whether application 
        /// </summary>
        public bool FirstLaunch
        {
            get { return GetValueOrDefault<bool>(FirstLaunchSettingKeyName, FirstLaunchSettingDefault); }
            set { AddOrUpdateValue(FirstLaunchSettingKeyName, value); }
        }

        /// <summary>
        /// Setting that determines whether application 
        /// </summary>
        public DateTime LastUpdated
        {
            get { return GetValueOrDefault<DateTime>(LastUpdatedSettingKeyName, LastUpdatedSettingDefault); }
            set { AddOrUpdateValue(LastUpdatedSettingKeyName, value); }
        }

        /// <summary>
        /// Raises the PropertyChanging event for the specified property if there are any subscribers.
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing.</param>
        protected virtual void OnPropertyChanging(string propertyName)
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
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}