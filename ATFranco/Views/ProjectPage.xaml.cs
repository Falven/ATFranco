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

namespace ATFranco.Views
{
    using ATFranco.Models;
    using ATFranco.Resources;
    using ATFranco.ViewModels;
    using DapperApps.Phone.Extensions;
    using Microsoft.Phone.Shell;
    using System;
    using System.Windows.Media;
    using System.Windows.Navigation;

    /// <summary>
    /// TODO
    /// </summary>
    public partial class ProjectPage : ViewBase
    {
        /// <summary>
        /// The uri used to navigate to this page.
        /// </summary>
        private Uri _uri;

        private Project _currentProject;

        /// <summary>
        /// TODO
        /// </summary>
        public ProjectPage()
        {
            InitializeComponent();

            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            var appBar = new ApplicationBar();
            appBar.BackgroundColor = (Color)Resources["PhoneBackgroundColor"];
            appBar.Mode = ApplicationBarMode.Minimized;

            // Create a new menu item with the localized string from AppResources.
            var pinMenuItem = new ApplicationBarMenuItem(AppResources.PinAppBarMenuItemText);
            pinMenuItem.Click += pinMenuItem_Click;

            appBar.MenuItems.Add(pinMenuItem);
            appBar.DisableMenuItems();

            ApplicationBar = appBar;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="nea">The event arguments for this navigation event.</param>
        protected override void OnNavigatedTo(NavigationEventArgs nea)
        {
            if (nea.NavigationMode == NavigationMode.New)
            {
                _uri = nea.Uri;
                string indexStr = null;
                if (NavigationContext.QueryString.TryGetValue("index", out indexStr))
                {
                    var viewmodel = new ProjectDetailsViewModel(Convert.ToInt32(indexStr));
                    DataContext = _currentProject = viewmodel.Project;
                }
            }

            if (!AppTiles.Instance.TileExists(_currentProject))
                ApplicationBar.EnableMenuItems();
            base.OnNavigatedTo(nea);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pinMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationBar.DisableMenuItems();
            AppTiles.Instance.Pin(_currentProject);
        }

        protected override void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            base.Image_Tap(sender, e);
        }
    }
}