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
    using ATFranco.Resources;
    using DapperApps.Phone.Extensions;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using Microsoft.Phone.Tasks;
    using Microsoft.Xna.Framework.Media;
    using Microsoft.Xna.Framework.Media.PhoneExtensions;
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;

    /// <summary>
    /// Page that displays an image with the url provided as a query from navigation arguments.
    /// </summary>
    public partial class ImagePage : ViewBase
    {
        /// <summary>
        /// TODO
        /// </summary>
        private string _imageName;

        /// <summary>
        /// The BitmapImage representation of this Image's ImageSource.
        /// </summary>
        private BitmapSource _imageBitmap;

        /// <summary>
        /// The picture representation of this ImagePage's PTZImage.
        /// </summary>
        private Picture _imagePicture;

        /// <summary>
        /// Construct an ImagePage.
        /// </summary>
        public ImagePage()
        {
            InitializeComponent();

            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar appBar = new ApplicationBar();
            appBar.BackgroundColor = (Color)Resources["PhoneBackgroundColor"];
            appBar.Opacity = 0.0d;
            appBar.StateChanged += ApplicationBar_StateChanged;

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem shareMenuItem = new ApplicationBarMenuItem(AppResources.ShareAppBarMenuItemText);
            shareMenuItem.Click += shareMenuItem_Click;
            ApplicationBarMenuItem saveToPhoneMenuItem = new ApplicationBarMenuItem(AppResources.SaveToPhoneAppBarMenuItemText);
            saveToPhoneMenuItem.Click += saveToPhoneMenuItem_Click;

            appBar.MenuItems.Add(shareMenuItem);
            appBar.MenuItems.Add(saveToPhoneMenuItem);
            appBar.DisableMenuItems();

            ApplicationBar = appBar;
        }

        /// <summary>
        /// Function called when an ImagePage becomes the active page in a frame.
        /// </summary>
        /// <param name="e">The event arguments for this navigation event.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string name = null;
            if (NavigationContext.QueryString.TryGetValue("name", out name))
            {
                BitmapImage bitmap = null;
                if (AppImages.Instance.Images.TryGetValue(name, out bitmap))
                {
                    _imageName = name;
                    Image.Source = _imageBitmap = bitmap;
                    if (!AppImages.Instance.DisallowedImages.ContainsKey(name))
                    {
                        ApplicationBar.EnableMenuItems();
                    }
                }
            }
        }

        /// <summary>
        /// Event handler called when the ApplicationBar changes states.
        /// </summary>
        /// <param name="sender">The appbar menu items that raised this event.</param>
        /// <param name="e">The event arguments for this event.</param>
        private void ApplicationBar_StateChanged(object sender, ApplicationBarStateChangedEventArgs e)
        {
            if (null != e)
            {
                ApplicationBar.Opacity = e.IsMenuVisible ? 0.99d : 0.0d;
            }
        }

        /// <summary>
        /// Event handler called when the 'Save to Phone' menu item is clicked.
        /// </summary>
        /// <param name="sender">The appbar menu items that raised this event.</param>
        /// <param name="ea">The event arguments for this event.</param>
        private void saveToPhoneMenuItem_Click(object sender, EventArgs ea)
        {
            using (IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForApplication())
            using (MediaLibrary mediaLib = new MediaLibrary())
            {
                try
                {
                    // Delete the bitmap from isolated storage if it exists.
                    if (!isoStorage.FileExists(_imageName))
                    {
                        // Save bitmap to Isolated Storage.
                        WriteableBitmap wb = new WriteableBitmap(_imageBitmap);
                        Stream fileStream = isoStorage.CreateFile(_imageName);
                        wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
                        fileStream.Close();
                    }

                    // If the picture has not been saved to the MediaLibrary yet.
                    if (null == (_imagePicture = mediaLib.SavedPictures.Get(_imageName)))
                    {
                        // Save the picture to the MediaLibrary.
                        Stream fileStream = isoStorage.OpenFile(_imageName, FileMode.Open, FileAccess.Read);
                        _imagePicture = mediaLib.SavePicture(_imageName, fileStream);
                        fileStream.Close();
                    }
                }
                catch (Exception e)
                {
                    AppLogger.Instance.LogException(e, "We were unable to save this picture.");
                }
            }
        }

        /// <summary>
        /// Event handler called when the 'Share...' menu item is clicked.
        /// </summary>
        /// <param name="sender">The appbar menu items that raised this event.</param>
        /// <param name="e">The event arguments for this event.</param>
        private void shareMenuItem_Click(object sender, EventArgs e)
        {
            // Make sure the picture exists in the
            // medialibrary before attempting to share it.
            if (null == _imagePicture)
            {
                saveToPhoneMenuItem_Click(null, null);
            }

            // Share the picture from the medialibrary.
            ShareMediaTask share = new ShareMediaTask();
            share.FilePath = _imagePicture.GetPath();
            share.Show();
        }
    }
}