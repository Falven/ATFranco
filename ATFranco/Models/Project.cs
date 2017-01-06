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
    using Microsoft.Phone.Shell;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO
    /// </summary>
    public class Project : PropertyNotificationBase, IAppTile
    {
        private const string ISO_DIR = "Projects";

        private int _id;
        private string _title;
        private string _location;
        private string _description;
        private ProjectClassification _type;
        private ObservableCollection<BitmapImage> _images;

        /// <summary>
        /// Directory that tells AppStorage where to save project images.
        /// </summary>
        public string IsoDir
        {
            get { return ISO_DIR; }
        }

        /// <summary>
        /// Id that tells AppStorage where to save images for this specific project.
        /// </summary>
        public int Id
        {
            get { return _id; }
            internal set
            {
                if (value != _id)
                {
                    OnPropertyChanging("Id");
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        /// <summary>
        /// The label for an ATFranco project.
        /// </summary>
        public string Label
        {
            get { return string.Format("{0} - {1}", Title, Location); }
        }

        /// <summary>
        /// The title for an ATFranco project.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    OnPropertyChanging("Title");
                    OnPropertyChanging("Label");
                    _title = value;
                    OnPropertyChanged("Title");
                    OnPropertyChanged("Label");
                }
            }
        }

        /// <summary>
        /// Where this project took place.
        /// </summary>
        public string Location
        {
            get { return _location; }
            set
            {
                if (value != _location)
                {
                    OnPropertyChanging("Location");
                    OnPropertyChanging("Label");
                    _location = value;
                    OnPropertyChanged("Location");
                    OnPropertyChanged("Label");
                }
            }
        }

        /// <summary>
        /// The description for an ATFranco project.
        /// Details on the project.
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
        /// The type of project this was.
        /// </summary>
        public ProjectClassification Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    OnPropertyChanging("Type");
                    _type = value;
                    OnPropertyChanged("Type");
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
        /// Get the NavigationUri for a Project AppTile.
        /// Or, where the tile Navigates to when tapped.
        /// </summary>
        public Uri NavigationUri
        {
            get { return new Uri(string.Format("/Project/{0}", Id), UriKind.Relative); }
        }

        /// <summary>
        /// Get the TileData for a Project AppTile.
        /// </summary>
        public ShellTileData TileData
        {
            get
            {
                var imagePaths = AppStorage.Instance.GetTileImagePaths(this);
                return new CycleTileData
                {
                    Count = Images.Count,
                    CycleImages = imagePaths,
                    Title = Label
                };
            }
        }
    }

    /// <summary>
    /// A classification for the type of an ATFranco project.
    /// </summary>
    public enum ProjectClassification
    {
        Residential,
        Institutional,
        LeisureAndResort,
        Specialty
    };
}