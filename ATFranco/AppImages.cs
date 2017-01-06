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
    using DapperApps.Phone.Collections.ObjectModel;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using Windows.Storage;

    /// <summary>
    /// App-level class that manages images. Allows users to check or add images that are disallowed
    /// from being downloaded or shared, and hook an ImageOpened and ImageClosed event that will
    /// handle saving, loading, and exception handling of images.
    /// </summary>
    internal class AppImages : SingletonBase<AppImages>
    {
        private const string IMAGE_PATH = "Assets";
        private const string ERROR_IMAGE_DARK = "ImageFailed_Dark.png";
        private const string ERROR_IMAGE_LIGHT = "ImageFailed_Light.png";
        private const string DAPPER_IMAGE = "DapperLogo.png";

        private readonly Uri ERROR_IMAGE_DARK_URI;
        private readonly Uri ERROR_IMAGE_LIGHT_URI;

        internal readonly Uri ERROR_IMAGE_URI;
        internal readonly string ERROR_IMAGE_NAME;

        private IDictionary<string, BitmapImage> _disallowedImages;
        private IDictionary<string, BitmapImage> _images;

        public AppImages()
        {
            ERROR_IMAGE_DARK_URI = new Uri(string.Format("{0}/{1}", IMAGE_PATH, ERROR_IMAGE_DARK), UriKind.Relative);
            ERROR_IMAGE_LIGHT_URI = new Uri(string.Format("{0}/{1}", IMAGE_PATH, ERROR_IMAGE_LIGHT), UriKind.Relative);

            DisallowedImages.Add(ERROR_IMAGE_DARK, new BitmapImage(ERROR_IMAGE_DARK_URI));
            DisallowedImages.Add(ERROR_IMAGE_LIGHT, new BitmapImage(ERROR_IMAGE_LIGHT_URI));

            if ((Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible)
            {
                ERROR_IMAGE_URI = ERROR_IMAGE_DARK_URI;
                ERROR_IMAGE_NAME = ERROR_IMAGE_DARK;
                Images.Add(ERROR_IMAGE_DARK, new BitmapImage(ERROR_IMAGE_URI));
            }
            else
            {
                ERROR_IMAGE_URI = ERROR_IMAGE_LIGHT_URI;
                ERROR_IMAGE_NAME = ERROR_IMAGE_LIGHT;
                Images.Add(ERROR_IMAGE_LIGHT, new BitmapImage(ERROR_IMAGE_URI));
            }
        }

        /// <summary>
        /// All of the in-memory loaded images for this application.
        /// </summary>
        internal IDictionary<string, BitmapImage> Images
        {
            get
            {
                if (null == _images)
                    _images = new ObservableDictionary<string, BitmapImage>();
                return _images;
            }
        }

        /// <summary>
        /// Dictionary of images that are not allowed to be shared, pinned, or saved.
        /// </summary>
        internal IDictionary<string, BitmapImage> DisallowedImages
        {
            get
            {
                if (null == _disallowedImages)
                    _disallowedImages = new ObservableDictionary<string, BitmapImage>();
                return _disallowedImages;
            }
        }

        /// <summary>
        /// Adds the provided image to the list of images disallowed from saving or sharing.
        /// </summary>
        /// <param name="image">The image to disallow sharing or saving of.</param>
        internal void Disallow(BitmapImage image)
        {
            var name = (string)image.GetValue(FrameworkElement.NameProperty);
            var path = image.UriSource;
            if (null == name)
                throw new ArgumentException("The provided image must have a FrameworkElement.NameProperty Dependency Property.");
            if (null == path)
                throw new ArgumentException("The provided image must have a valid UriSource property.");

        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void Image_ImageOpened(object sender, RoutedEventArgs e)
        {
            var image = (BitmapImage)sender;
            string imageName = (string)image.GetValue(FrameworkElement.NameProperty);
            Images.Add(imageName, image);
            AppLoading.Instance.IsLoading = false;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            var bitmap = (BitmapImage)sender;
            bitmap.SetValue(FrameworkElement.NameProperty, ERROR_IMAGE_NAME);
            bitmap.UriSource = ERROR_IMAGE_URI;
            AppLoading.Instance.IsLoading = false;
        }
    }
}