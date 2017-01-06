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
    using System;
    using System.Windows;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO
    /// </summary>
    public class AboutViewModel : ViewModelBase
    {
        private ContactInfo _dapperContactInfo;

        /// <summary>
        /// TODO
        /// </summary>
        public AboutViewModel()
        {
            var dapperImage = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
            var dapperName = "DapperLogo.png";
            dapperImage.SetValue(FrameworkElement.NameProperty, dapperName);
            dapperImage.ImageOpened += AppImages.Instance.Image_ImageOpened;
            dapperImage.ImageFailed += AppImages.Instance.Image_ImageFailed;
            dapperImage.UriSource = new Uri("/Assets/DapperLogo.png", UriKind.Relative);
            AppImages.Instance.DisallowedImages.Add(dapperName, dapperImage);
            AppLoading.Instance.IsLoading = true;

            DapperContactInfo = new ContactInfo
            {
                Image = dapperImage,
                Location = "",
                Address = "",
                Telephone = "",
                Fax = "",
                Email = "dapperapps@outlook.com",
                Subject = "Dapper-Apps Inquiry",
                WebSite = @"http://www.dapper-apps.com"
            };
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ContactInfo DapperContactInfo
        {
            get { return _dapperContactInfo; }
            set
            {
                if (value != _dapperContactInfo)
                {
                    OnPropertyChanging("DapperContactInfo");
                    _dapperContactInfo = value;
                    OnPropertyChanged("DapperContactInfo");
                }
            }
        }
    }
}
