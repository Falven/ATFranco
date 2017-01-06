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

    /// <summary>
    /// The ViewModel that gets and binds Press and Award objects to the MainPage.
    /// </summary>
    internal class PressAwardsViewModel : ViewModelBase
    {
        private ObservableCollection<Publicity> _awards;
        private ObservableCollection<Publicity> _press;

        /// <summary>
        /// TODO
        /// </summary>
        public PressAwardsViewModel()
        {
            Awards = new ObservableCollection<Publicity>
            {
                new Publicity { Title = "Design Award:", Description = "The “Bandstand” at the City of Fort Lauderdale Riverwalk project"},
                new Publicity { Title = "Award for Outstanding Achievement in Urban Environmental Design:", Description = "Cardinal Gibbon’s High School’s Community"},
                new Publicity { Title = "Design Award:", Description = "Adios Golf Club, Coconut Creek, FL"}
            };

            Press = new ObservableCollection<Publicity>
            {
                new Publicity { Title = "Luxe Magazine, South Florida", Uri = new Uri("http://www.atfranco.com/fl15_feature_franco.pdf", UriKind.Absolute) }
            };
        }

        public ObservableCollection<Publicity> Awards
        {
            get { return _awards; }
            set
            {
                OnPropertyChanging("Awards");
                _awards = value;
                OnPropertyChanged("Awards");
            }
        }

        public ObservableCollection<Publicity> Press
        {
            get { return _press; }
            set
            {
                OnPropertyChanging("Press");
                _press = value;
                OnPropertyChanged("Press");
            }
        }

        public void Award_Tap()
        {

        }
    }
}
