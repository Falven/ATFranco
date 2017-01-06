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
    using ATFranco.ViewModels;
    using DapperApps.Phone.Controls;
    using Microsoft.Phone.Controls;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System.Windows.Threading;

    /// <summary>
    /// TODO
    /// </summary>
    public partial class FeaturedPage : ViewBase
    {
        private FeaturedViewmodel _viewModel;

        /// <summary>
        /// TODO
        /// </summary>
        public FeaturedPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ImagePreview.FreezePreviews((FrameworkElement)Panorama);
            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="nea"></param>
        protected override void OnNavigatedTo(NavigationEventArgs nea)
        {
            if (nea.NavigationMode == NavigationMode.New)
            {
                AppLoading.Instance.IsLoading = true;
                DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.50d) };
                timer.Tick +=
                    (s, e) =>
                    {
                        if (null == _viewModel)
                        {
                            Panorama.DataContext = _viewModel = new FeaturedViewmodel();
                            foreach (PanoramaItem item in _viewModel.FeaturedItems)
                            {
                                var image = item.Content as ImagePreview;
                                if (null != image)
                                    image.Tap += base.Image_Tap;
                            }
                        }
                        timer.Stop();
                        AppLoading.Instance.IsLoading = false;
                    };
                timer.Start();
            }

            if (nea.NavigationMode == NavigationMode.Back)
            {
                ImagePreview.UnfreezePreviews((FrameworkElement)Panorama.SelectedItem);
            }

            base.OnNavigatedTo(nea);
        }

        /// <summary>
        /// Event handler called whenever the Panorama changes PanoramaItem selection.
        /// </summary>
        /// <param name="sender">The Panorama.</param>
        /// <param name="scea">Arguments for this event.</param>
        private void Panorama_SelectionChanged(object sender, SelectionChangedEventArgs scea)
        {
            foreach (PanoramaItem panoramaItem in scea.AddedItems)
            {
                ImagePreview.UnfreezePreviews((FrameworkElement)panoramaItem);
            }

            foreach (PanoramaItem panoramaItem in scea.RemovedItems)
            {
                ImagePreview.FreezePreviews((FrameworkElement)panoramaItem);
            }
        }
    }
}