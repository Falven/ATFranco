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
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO
    /// </summary>
    public class Employee : PropertyNotificationBase
    {
        private string _name;
        private BitmapImage _image;
        private string _title;
        private string _description;

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
        public string Title
        {
            get { return _title; }
            set
            {
                OnPropertyChanging("Title");
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                OnPropertyChanging("Description");
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    OnPropertyChanging("Name");
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
    }
}
