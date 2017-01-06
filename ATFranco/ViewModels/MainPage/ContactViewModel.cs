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

namespace ATFranco.ViewModels
{
    using ATFranco.Models;
    using System.Collections.ObjectModel;

    /// <summary>
    /// TODO
    /// </summary>
    class ContactViewModel : ViewModelBase
    {
        private ObservableCollection<ContactInfo> _contactInfo;

        /// <summary>
        /// TODO
        /// </summary>
        public ContactViewModel()
        {
            // Contact Info
            ContactInfo = new ObservableCollection<ContactInfo>
            {
                new ContactInfo
                { 
                    Location = "FLORIDA",
                    Address = "AT Franco & Associates\n500 SE 11th Court\nFort Lauderdale, FL 33316",
                    Telephone = "954-523-9609",
                    Fax = "954-779-7207",
                    Email = "atfranco@outlook.com",
                    WebSite = @"http://www.atfranco.com"
                },
                new ContactInfo
                {
                    Location = "CONNETICUT",
                    Address = "AT Franco & Associates\n44 Davenport Avenue\nGreenwich, CT 06837",
                    Telephone = "203-625-7525",
                    Fax = "203-625-7526",
                    Email = "atfranco@outlook.com",
                    WebSite = @"http://www.atfranco.com"
                }
            };
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<ContactInfo> ContactInfo
        {
            get { return _contactInfo; }
            set
            {
                OnPropertyChanging("ContactInfo");
                _contactInfo = value;
                OnPropertyChanged("ContactInfo");
            }
        }
    }
}
