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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO
    /// </summary>
    public class Studio : PropertyNotificationBase
    {
        private string _location;
        private BitmapImage _image;
        private string _quote;
        private string _history;

        /// <summary>
        /// TODO
        /// </summary>
        public string Location
        {
            get { return _location; }
            set
            {
                if (value != _location)
                {
                    OnPropertyChanging("Location");
                    _location = value;
                    OnPropertyChanged("Location");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                OnPropertyChanging("Image");
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Quote
        {
            get { return _quote; }
            set
            {
                OnPropertyChanging("Quote");
                _quote = value;
                OnPropertyChanged("Quote");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string History
        {
            get { return _history; }
            set
            {
                OnPropertyChanging("History");
                _history = value;
                OnPropertyChanged("History");
            }
        }
    }
}
