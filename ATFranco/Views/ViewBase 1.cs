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
    using DapperApps.Phone.Controls;
    using Microsoft.Phone.Controls;
    using System;
    using System.Data.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Contains common code among all ATFranco pages.
    /// </summary>
    public class ViewBase : PhoneApplicationPage
    {
        private int _lineIndex;
        private object _lastDataContext;

        /// <summary>
        /// Sets the incremental line index for each subitem in an
        /// itemscontrol whose datacontext remains the same.
        /// </summary>
        /// <param name="sender">The itemscontrol that raised this event.</param>
        /// <param name="e">The arguments for this event.</param>
        protected virtual void ItemsControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var itemsControl = (ItemsControl)sender;
            var itemsDataContext = itemsControl.DataContext;

            if (_lastDataContext != itemsDataContext)
            {
                _lineIndex = 1;
                _lastDataContext = itemsDataContext;
            }

            var items = itemsControl.Items;

            if (null != items)
            {
                var count = items.Count;
                var generator = itemsControl.ItemContainerGenerator;
                for (int i = 0; i < count; i++)
                {
                    generator.ContainerFromIndex(i).SetValue(SlideInEffect.LineIndexProperty, _lineIndex++);
                }
            }
        }

        /// <summary>
        /// Most pages display images, and we want ot allow a user to navigate to the ImagePage for such image.
        /// </summary>
        /// <param name="sender">The Image or PreviewImage that raised this event.</param>
        /// <param name="e">The argument for this event.</param>
        protected virtual void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var previewImage = sender as ImagePreview;
            var image = sender as Image;
            ImageSource source = null;

            if (null != previewImage)
            {
                source = previewImage.Source;
            }
            else
            {
                if (null != image)
                {
                    source = image.Source;
                }
            }

            if (null != source)
            {
                string sourceName = (string)source.GetValue(FrameworkElement.NameProperty);
                NavigationService.Navigate(new Uri(string.Format(@"/Image/{0}", sourceName), UriKind.Relative));
            }
        }
    }
}
