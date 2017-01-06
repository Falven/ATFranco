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
    using System.Device.Location;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO
    /// </summary>
    public class ContactInfo : PropertyNotificationBase, IMapable, ICallable, IEmailable, IBrowsable
    {
        private BitmapImage _image;
        private string _location;
        private string _address;
        private string _telephone;
        private string _fax;
        private string _email;
        private string _website;

        public ContactInfo()
        {
            Subject = "AT Franco & Associates Inquiry";
            Body = "\n\nSent from the ATFranco App!";
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
        public string Location
        {
            get { return _location; }
            set
            {
                OnPropertyChanging("Location");
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Address
        {
            get { return _address; }
            set
            {
                OnPropertyChanging("Address");
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Telephone
        {
            get { return _telephone; }
            set
            {
                OnPropertyChanging("TelephoneNumber");
                _telephone = value;
                OnPropertyChanged("TelephoneNumber");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set
            {
                OnPropertyChanging("Fax");
                _fax = value;
                OnPropertyChanged("Fax");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                OnPropertyChanging("Email");
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string WebSite
        {
            get { return _website; }
            set
            {
                OnPropertyChanging("WebSite");
                _website = value;
                OnPropertyChanged("WebSite");
            }
        }

        public GeoCoordinate Center
        {
            get { return null; }
        }

        public string SearchTerm
        {
            get { return _address; }
        }

        public double ZoomLevel
        {
            get { return 0.0d; }
        }

        public string DisplayName
        {
            get { return string.Format("AT Franco {0}", Location); }
        }

        public string PhoneNumber
        {
            get { return Telephone; }
        }

        public string Bcc
        {
            get { return null; }
        }

        public string Body { get; set; }

        public string Cc
        {
            get { return null; }
        }

        public int? CodePage
        {
            get { return null; }
        }

        public string Subject { get; set; }

        public string To
        {
            get { return Email; }
        }

        public Uri Uri
        {
            get { return new Uri(WebSite, UriKind.Absolute); }
        }
    }
}
