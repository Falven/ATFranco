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
    using DapperApps.Phone.Controls;
    using Microsoft.Phone.Controls;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO
    /// </summary>
    public class FeaturedViewmodel : ViewModelBase
    {
        /// <summary>
        /// TODO
        /// </summary>
        private ObservableCollection<PanoramaItem> _featuredItems;

        /// <summary>
        /// TODO
        /// </summary>
        public FeaturedViewmodel()
        {
            var hbstyle = (Style)App.Current.Resources["HyperlinkPresenterStyle"];
            var txstyle = (Style)App.Current.Resources["ATFrancoTextTitle2Style"];
            var thickness = new Thickness(0.0d, 6.0d, 0.0d, 6.0d);

            BitmapImage slide1 = null;
            var slide1Name = "04slide21.jpg";

            if (AppImages.Instance.Images.ContainsKey(slide1Name))
            {
                slide1 = AppImages.Instance.Images[slide1Name];
            }
            else
            {
                slide1 = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
                slide1.SetValue(FrameworkElement.NameProperty, slide1Name);
                slide1.ImageOpened += AppImages.Instance.Image_ImageOpened;
                slide1.ImageFailed += AppImages.Instance.Image_ImageFailed;
                slide1.UriSource = new Uri("http://www.atfranco.com/wp-content/uploads/2012/04/slide21.jpg", UriKind.Absolute);
                AppLoading.Instance.IsLoading = true;
            }

            BitmapImage slide2 = null;
            var slide2Name = "11slide3.jpg";

            if (AppImages.Instance.Images.ContainsKey(slide2Name))
            {
                slide2 = AppImages.Instance.Images[slide2Name];
            }
            else
            {
                slide2 = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
                slide2.SetValue(FrameworkElement.NameProperty, slide2Name);
                slide2.ImageOpened += AppImages.Instance.Image_ImageOpened;
                slide2.ImageFailed += AppImages.Instance.Image_ImageFailed;
                slide2.UriSource = new Uri("http://www.atfranco.com/wp-content/uploads/2012/11/slide3.jpg", UriKind.Absolute);
                AppLoading.Instance.IsLoading = true;
            }

            BitmapImage slide3 = null;
            var slide3Name = "12slide4-980x397.jpg";

            if (AppImages.Instance.Images.ContainsKey(slide3Name))
            {
                slide3 = AppImages.Instance.Images[slide3Name];
            }
            else
            {
                slide3 = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
                slide3.SetValue(FrameworkElement.NameProperty, slide3Name);
                slide3.ImageOpened += AppImages.Instance.Image_ImageOpened;
                slide3.ImageFailed += AppImages.Instance.Image_ImageFailed;
                slide3.UriSource = new Uri("http://www.atfranco.com/wp-content/uploads/2012/12/slide4-980x397.jpg", UriKind.Absolute);
                AppLoading.Instance.IsLoading = true;
            }

            BitmapImage slide4 = null;
            var slide4Name = "11slide4.jpg";

            if (AppImages.Instance.Images.ContainsKey(slide4Name))
            {
                slide4 = AppImages.Instance.Images[slide4Name];
            }
            else
            {
                slide4 = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
                slide4.SetValue(FrameworkElement.NameProperty, slide4Name);
                slide4.ImageOpened += AppImages.Instance.Image_ImageOpened;
                slide4.ImageFailed += AppImages.Instance.Image_ImageFailed;
                slide4.UriSource = new Uri("http://www.atfranco.com/wp-content/uploads/2012/11/slide4.jpg", UriKind.Absolute);
                AppLoading.Instance.IsLoading = true;
            }

            FeaturedItems = new ObservableCollection<PanoramaItem>
            {
                new PanoramaItem
                {
                    Content = new ImagePreview { Source = slide1, IsFrozen = false }
                },
                new PanoramaItem
                {
                    Content = new ImagePreview { Source = slide2, IsFrozen = true }
                },
                new PanoramaItem
                {
                    Content = new ImagePreview { Source = slide3, IsFrozen = true }
                },
                new PanoramaItem
                {
                    Content = new ImagePreview { Source = slide4, IsFrozen = true }
                },
                new PanoramaItem
                {
                    Content = new ItemsControl
                    {
                        Margin = new Thickness(12.0d, 12.0d, 0, 0),
                        ItemsSource = new List<object>
                        {
                            new HyperlinkButton
                            {
                                NavigateUri = new Uri("/Main/0", UriKind.Relative),
                                Style = hbstyle,
                                Margin = thickness,
                                Content = new TextBlock
                                {
                                    Text = "OUR STUDIOS",
                                    Style = txstyle
                                }
                            },
                            new HyperlinkButton
                            {
                                NavigateUri = new Uri("/Main/1", UriKind.Relative),
                                Style = hbstyle,
                                Margin = thickness,
                                Content = new TextBlock
                                {
                                    Text = "OUR TEAM",
                                    Style = txstyle
                                }
                            },
                            new HyperlinkButton
                            {
                                NavigateUri = new Uri("/Main/2", UriKind.Relative),
                                Style = hbstyle,
                                Margin = thickness,
                                Content = new TextBlock
                                {
                                    Text = "PROJECTS + CLIENTS",
                                    Style = txstyle
                                }
                            },
                            new HyperlinkButton
                            {
                                NavigateUri = new Uri("/Main/3", UriKind.Relative),
                                Style = hbstyle,
                                Margin = thickness,
                                Content = new TextBlock
                                {
                                    Text = "PRESS + AWARDS",
                                    Style = txstyle
                                }
                            },
                            new HyperlinkButton
                            {
                                NavigateUri = new Uri("/Main/4", UriKind.Relative),
                                Style = hbstyle,
                                Margin = thickness,
                                Content = new TextBlock
                                {
                                    Text = "CONTACT US",
                                    Style = txstyle
                                }
                            },
                            new HyperlinkButton
                            {
                                NavigateUri = new Uri("/Main/5", UriKind.Relative),
                                Style = hbstyle,
                                Margin = thickness,
                                Content = new TextBlock
                                {
                                    Text = "ABOUT",
                                    Style = txstyle
                                }
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<PanoramaItem> FeaturedItems
        {
            get { return _featuredItems; }
            set
            {
                OnPropertyChanging("FeaturedItems");
                _featuredItems = value;
                OnPropertyChanged("FeaturedItems");
            }
        }
    }
}