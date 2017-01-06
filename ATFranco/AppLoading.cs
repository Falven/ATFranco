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
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;

    /// <summary>
    /// TODO
    /// </summary>
    public class AppLoading : SingletonBase<AppLoading>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ProgressIndicator _indicator;
        private int _loadingCount;

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsLoading
        {
            get
            {
                return _loadingCount > 0;
            }
            set
            {
                bool loading = IsLoading;
                if (value)
                {
                    ++_loadingCount;
                }
                else
                {
                    --_loadingCount;
                }

                NotifyValueChanged();
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsDataManagerLoading { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public bool ActualIsLoading
        {
            get
            {
                return IsLoading || IsDataManagerLoading;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="frame"></param>
        public void Initialize(PhoneApplicationFrame frame)
        {
            _indicator = new ProgressIndicator();

            frame.Navigated += OnRootFrameNavigated;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRootFrameNavigated(object sender, NavigationEventArgs e)
        {
            var pp = e.Content as PhoneApplicationPage;
            if (pp != null)
            {
                pp.SetValue(SystemTray.ProgressIndicatorProperty, _indicator);
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if ("IsLoading" == e.PropertyName)
            {
                NotifyValueChanged();
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void NotifyValueChanged()
        {
            if (_indicator != null)
            {
                _indicator.IsIndeterminate = _loadingCount > 0 || IsDataManagerLoading;

                // for now, just make sure it's always visible.
                if (_indicator.IsVisible == false)
                {
                    _indicator.IsVisible = true;
                }
            }
        }
    }
}