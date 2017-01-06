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

namespace ATFranco.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO
    /// </summary>
    public class Project : ModelBase
    {
        /// <summary>
        /// TODO
        /// </summary>
        private string _title;

        /// <summary>
        /// TODO
        /// </summary>
        private string _location;

        /// <summary>
        /// TODO
        /// </summary>
        private string _description;

        /// <summary>
        /// TODO
        /// </summary>
        private string _type;

        /// <summary>
        /// TODO
        /// </summary>
        private bool _tooltipsLoaded;

        /// <summary>
        /// TODO
        /// </summary>
        private bool _imagesLoaded;

        /// <summary>
        /// TODO
        /// </summary>
        private string _pageLink;

        /// <summary>
        /// TODO
        /// </summary>
        private Collection<Uri> _tooltipLinks;

        /// <summary>
        /// TODO
        /// </summary>
        private Collection<Uri> _imageLinks;

        /// <summary>
        /// TODO
        /// </summary>
        private ObservableCollection<BitmapImage> _toolTips;

        /// <summary>
        /// TODO
        /// </summary>
        private ObservableCollection<BitmapImage> _images;

        /// <summary>
        /// TODO
        /// </summary>
        public Project(string title, string location, string description, string type, Collection<Uri> tooltipLinks, Collection<Uri> imageLinks)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentNullException("location");
            if (null == description)
                throw new ArgumentNullException("description");
            if (null == type)
                throw new ArgumentNullException("type");
            if (null == tooltipLinks)
                throw new ArgumentNullException("tooltipLinks");
            if (null == imageLinks)
                throw new ArgumentNullException("imageLinks");
            Title = title;
            Location = location;
            Description = description;
            Type = type;
            TooltipLinks = tooltipLinks;
            ImageLinks = imageLinks;
            ImagesLoaded = false;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    OnPropertyChanging("Title");
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Location
        {
            get { return _location; }
            set
            {
                if (value != _location)
                {
                    OnPropertyChanging("Location");
                    OnPropertyChanging("PageLinkTitle");
                    _location = value;
                    OnPropertyChanged("Location");
                    OnPropertyChanged("PageLinkTitle");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                if (value != _description)
                {
                    OnPropertyChanging("Description");
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    OnPropertyChanging("Type");
                    OnPropertyChanging("PageLinkTitle");
                    _type = value;
                    OnPropertyChanged("Type");
                    OnPropertyChanged("PageLinkTitle");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string PageLinkTitle
        {
            get { return Type + " - " + Location; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string PageLink
        {
            get { return _pageLink; }
            set
            {
                if (value != _pageLink)
                {
                    OnPropertyChanging("HyperLink");
                    _pageLink = value;
                    OnPropertyChanged("HyperLink");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool TooltipsLoaded
        {
            get { return _tooltipsLoaded; }
            set
            {
                if (value != _tooltipsLoaded)
                {
                    OnPropertyChanging("TooltipsLoaded");
                    _tooltipsLoaded = value;
                    OnPropertyChanged("TooltipsLoaded");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool ImagesLoaded
        {
            get { return _imagesLoaded; }
            private set
            {
                if (value != _imagesLoaded)
                {
                    OnPropertyChanging("ImagesLoaded");
                    _imagesLoaded = value;
                    OnPropertyChanged("ImagesLoaded");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public Collection<Uri> TooltipLinks
        {
            get { return _tooltipLinks; }
            set
            {
                if (value != _tooltipLinks)
                {
                    OnPropertyChanging("TooltipLinks");
                    _tooltipLinks = value;
                    OnPropertyChanged("TooltipLinks");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public Collection<Uri> ImageLinks
        {
            get { return _imageLinks; }
            set
            {
                if (value != _imageLinks)
                {
                    OnPropertyChanging("ImageLinks");
                    _imageLinks = value;
                    OnPropertyChanged("ImageLinks");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<BitmapImage> ToolTips
        {
            get { return _toolTips; }
            set
            {
                if (value != _toolTips)
                {
                    OnPropertyChanging("ToolTips");
                    _toolTips = value;
                    OnPropertyChanged("ToolTips");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<BitmapImage> Images
        {
            get { return _images; }
            set
            {
                if (value != _images)
                {
                    OnPropertyChanging("Images");
                    _images = value;
                    OnPropertyChanged("Images");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void LoadTooltips()
        {
            if (!TooltipsLoaded)
            {
                foreach (Uri uri in TooltipLinks)
                {
                    BitmapImage image = new BitmapImage(uri) { CreateOptions = BitmapCreateOptions.DelayCreation };
                    image.ImageOpened += Image_ImageOpened;
                    image.ImageFailed += Image_ImageFailed;
                    ToolTips.Add(image);
                }
                TooltipsLoaded = true;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void LoadImages()
        {
            if (!ImagesLoaded)
            {
                foreach (Uri uri in ImageLinks)
                {
                    GlobalLoading.Instance.IsLoading = true;
                    BitmapImage image = new BitmapImage(uri) { CreateOptions = BitmapCreateOptions.DelayCreation };
                    image.ImageOpened += Image_ImageOpened;
                    image.ImageFailed += Image_ImageFailed;
                    Images.Add(image);
                }
                ImagesLoaded = true;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_ImageOpened(object sender, RoutedEventArgs e)
        {
            GlobalLoading.Instance.IsLoading = false;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            BitmapImage bitmapImage = (BitmapImage)sender;
            bitmapImage.UriSource = App.ErrorImageSource;
            GlobalLoading.Instance.IsLoading = false;
        }
    }
}
