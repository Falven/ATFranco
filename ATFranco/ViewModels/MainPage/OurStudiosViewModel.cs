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
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO
    /// </summary>
    internal class OurStudiosViewModel : ViewModelBase
    {
        private ObservableCollection<Studio> _studios;

        /// <summary>
        /// TODO
        /// </summary>
        public OurStudiosViewModel()
        {
            var studioImage = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
            studioImage.SetValue(FrameworkElement.NameProperty, "11Capture-610x200.png");
            studioImage.ImageOpened += AppImages.Instance.Image_ImageOpened;
            studioImage.ImageFailed += AppImages.Instance.Image_ImageFailed;
            studioImage.UriSource = new Uri("http://www.atfranco.com/wp-content/uploads/2012/11/Capture-610x200.png", UriKind.Absolute);
            AppLoading.Instance.IsLoading = true;

            Studios = new ObservableCollection<Studio>
            {
                new Studio
                {
                    Location = "FLORIDA",
                    Image = studioImage,
                    Quote = "\"The difference between architecture and sculpture is that architecture is used by people, while sculpture is simply admired. Our goal is to create something that is equally beautiful and functional.\" –Kiko Franco, AIA, Principal",
                    History = "\tIn 1988 Kiko Franco found himself fascinated with the direction in which architecture was moving. The industry was transitioning from hand drafting on paper to CAD drawings. Eager to start designing digitally, and wanting to create a small firm where both the design and use of each space were treated with equal importance, he founded AT Franco & Associates Inc.\n\n\tIn 1995, Kiko identified a common need amongst many of his clients: project management. Since then, AT Franco has specialized in this area, coordinating all aspects of the design-build process including architectural design, site planning, construction, interior design, trade coordination, and property management. Twenty four years since its inception, AT Franco & Associates is proud to be a small firm made up of three talented architects and support staff that offer personalized service to each client, no matter the size of the project. Kiko explains the company\'s approach to client service simply: \"Some clients design and build a space only once, some do it over and over again. No matter what, we want to make sure the opportunity to work with a client is never wasted and always memorable.\"\n\n\tAT Franco\'s main office is located in Fort Lauderdale, Florida near the Hollywood International Airport and some of the world\'s most beautiful beaches. Nestled amongst lush vegetation, the office pays tribute to its tropical setting. The two-building property was purchased and renovated in 2007 and features modern workstations in an open floor plan, making it conducive to employee interaction, comfortable client meetings and the occasional cocktail party.\n\n\tIn 2012, AT Franco will open a second office in Greenwich, Connecticut."
                }
            };
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<Studio> Studios
        {
            get { return _studios; }
            set
            {
                if (value != _studios)
                {
                    OnPropertyChanging("Studios");
                    _studios = value;
                    OnPropertyChanged("Studios");
                }
            }
        }
    }
}