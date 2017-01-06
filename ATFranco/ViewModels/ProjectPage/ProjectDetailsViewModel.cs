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
    using DapperApps.Media.Imaging;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO
    /// </summary>
    internal class ProjectDetailsViewModel : ViewModelBase
    {
        public event EventHandler<EventArgs> FinishedLoading;
        private const int BORDER_THRESHOLD = (255 << 24) + (240 << 16) + (240 << 8) + 240;

        private int _workload;
        private Project _project;
        private BitmapCreateOptions _createOptions;

        /// <summary>
        /// TODO
        /// </summary>
        public ProjectDetailsViewModel(int id)
        {
            _createOptions = BitmapCreateOptions.IgnoreImageCache;
            // Hardcoded loading for now
            switch (id)
            {
                case 0:
                    LoadMiami(id);
                    break;
                case 1:
                    LoadBoca(id);
                    break;
                case 2:
                    LoadIslamorada(id);
                    break;
                case 3:
                    LoadBahamas(id);
                    break;
                case 4:
                    LoadStar(id);
                    break;
                case 5:
                    LoadLauderdale(id);
                    break;
                case 6:
                    LoadPortsmouth(id);
                    break;
                case 7:
                    LoadGibbons(id);
                    break;
                case 8:
                    LoadJois(id);
                    break;
                case 9:
                    LoadAdios(id);
                    break;
                case 10:
                    LoadBroken(id);
                    break;
                case 11:
                    LoadHarbour(id);
                    break;
                case 12:
                    LoadIsleworth(id);
                    break;
                case 13:
                    LoadAfrica(id);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public Project Project
        {
            get { return _project; }
            set
            {
                if (value != _project)
                {
                    OnPropertyChanging("Project");
                    _project = value;
                    OnPropertyChanged("Project");
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadMiami(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "What originally set out to be a renovation of an \"architecturally significant\" 1930\'s home, as deemed by the City of Miami Beach, eventually turned into a complete demolition after determining that the expense of saving the structure would drastically increase construction costs. Both the City and homeowner were in agreement that the new home should reflect the original massing and detailing of the pre-existing home, so ATFA designed a new home perfectly blended the original Mediterranean style, with modern touches that were appealing to the homeowner. The result was a 9,500 sq. ft home with panoramic views of Biscayne Bay and Sunset Islands.";

            // Crop images before adding them to project.
            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic1.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic2.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic3.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic4.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic5.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic6.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic7.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic8.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic9.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic10.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic11.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/51/images/pic12.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadBoca(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/52/images/img_1.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/52/images/img_2.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/52/images/img_1375.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/52/images/img_1380.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/52/images/img_1390.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadIslamorada(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "Fronting the beautiful Florida Bay, this private enclave was designed to be reminiscent of \"conch style\" architecture, traditional to the Florida Keys. At over 15,000 square feet, the complex includes a main house, two guesthouses, three ancillary support buildings, a garage and a boathouse. In addition to the main residence design, ATFA has been retained to complete various projects throughout the years for the client. Such projects include a custom hot tub with sloped entry and coping and a pool cabana complete with outdoor executive chef kitchen and seating area.";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/36/images/dsc00493.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/36/images/islamorada1.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/36/images/islamorada2.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadBahamas(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "To respond to the waterfront and beachside open lot, the main house, detached bunkroom and guest suite were developed to take advantage of the sloping terrain and panoramic ocean views. Incorporation of hardie material on the exterior, cistern\'s located beneath the building, and impact rated doors and windows responded to the owner\'s request for minimum maintenance and durability during storm surge. The original home was constructed in 2003, and in 2006, ATFA was retained again to create a detached guesthouse which was built the following year. The guesthouse was designed to reflect the same style and incorporate similar materials and building methods as completed with the main residence. Located at the property\'s high point, full 360 degree panoramic views allow guests a truly unique view. Expansive porches offer a tranquil area to take in the beautiful views of Abaco Island.";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/37/images/img_0973.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/37/images/img_0999.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/37/images/img_1007.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadStar(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "In collaboration with master thatchers Ace Thatch & Bamboo, Inc., ATFA provided architectural design services for the ancillary pool structures for this very exclusive private residence located on Star Island in Miami Beach. These unique pool pavilions were constructed of exotic hardwood timbers and traditionally thatched Turkish water reed roofs that are reflective of the architectural style of Bali.";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/53/images/pic1.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/53/images/pic2.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/53/images/pic3.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/53/images/pic4.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/53/images/pic5.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadLauderdale(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "In collaboration with master thatchers Ace Thatch & Bamboo, Inc., ATFA provided architectural design services for the ancillary pool structures for this very exclusive private residence located on Star Island in Miami Beach. These unique pool pavilions were constructed of exotic hardwood timbers and traditionally thatched Turkish water reed roofs that are reflective of the architectural style of Bali.";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/48/images/front_view.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/48/images/img_0036.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/48/images/img_0070.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/48/images/living_room.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/48/images/bath_tub.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadPortsmouth(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "In collaboration with master thatchers Ace Thatch & Bamboo, Inc., ATFA provided architectural design services for the ancillary pool structures for this very exclusive private residence located on Star Island in Miami Beach. These unique pool pavilions were constructed of exotic hardwood timbers and traditionally thatched Turkish water reed roofs that are reflective of the architectural style of Bali.";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/42/images/ah_streetscape_i.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/42/images/img_0898.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/42/images/img_1924.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/42/images/img_1981.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/42/images/img_1993.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/42/images/img_2043.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/42/images/img_2052.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/42/images/img_2117.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/42/images/pcc_rear_patio.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadGibbons(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "The intent of the multi-goal project was to create a lobby for the existing gym to accommodate a lounge area with trophy display cases, concession stand and restrooms, and a practice court on the second floor with a sports classroom. In addition, the building, located in a prominent part of the school’s center area, established the new ‘architectural look’ for the school, in order to create new campus atmosphere, while taking into account the students’ circulation patterns. To further accomplish this, an elevated walkway, new student courtyard were also added. Night illumination for both safety and improving nighttime school functions was also incorporated into the design.";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/40/images/day_view_2.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/40/images/hall2.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/40/images/night_view_2.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadJois(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "With two other locations – one in Sydney, Australia and the other in Encinitas, California – this facility was designed to become the company\'s flagship studio and retail store. ATFA was retained to manage a complete design team of architects, engineers, interior designers and landscape arhictects, who was challenged with the task of preserving the original character of the existing building, improving its impact on the community, and developing a strong brand image for Jois Yoga.\n\nThe design consists of two areas: the \"shala\" or studio, used for yoga practice, and a retail space used as a clothing and accessories boutique. The roof of the original building was raised to give the space high ceilings and another level of clerestory windows were added to double the amount of natural light and air. SOLATUBE skylights were added to allow sunlight to enter through the roof during the day, which reduces the need for electrical lighting and saves energy. Completed in April 2012, Jois Yoga\'s Greenwich location evokes simplicity, tranquility, and transformation – qualities that are all synonymous with the practice of yoga.";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/31/images/jois_0019.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/31/images/jois_0024.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/31/images/jois_0046.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/31/images/jois_0059_1.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/31/images/jois_0071.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/31/images/jois07.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/31/images/jois24.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/31/images/jois37.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/31/images/jois44.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadAdios(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "Set in a magnificent Arnold Palmer designed golf course, this 27,000 square foot Clubhouse was intended to represent old Florida\'s \"rustic ranch house\" architecture. An imposing wood frame structure was used to provide a warm and elegant character throughout. Additional renovations included a new horseshoe-shaped bar, expanded dining space, a new exercise room, a complete overhaul of the restrooms and showers, as well as a kitchen expansion. The clubhouse was also remodeled to comply with the Americans with Disabilities Act regulations.";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/30/images/adios1.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/30/images/adios2.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/30/images/adios3.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/30/images/adiosbar.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadBroken(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/44/images/brokensound1.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/44/images/brokensound2.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadHarbour(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "The architecture of this seaside resort was designed to embrace the Dutch style of the Netherland Antilles, as well as provide an image for the marketing efforts of Harbour Village. ATFA\'s designs include the Health Spa, Yacht Club, Admiral\'s Tavern Lighthouse Restaurant, The Diver\'s Inn, Dive Shop, Sales Center, several plazas and other related facilities. Harbour Village is included among the best twelve seaside spa retreats around the world, according to Harper\'s Bazaar.";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/41/images/harbour1.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/41/images/harbour2.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/41/images/harbour3.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadIsleworth(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/50/images/isleworth1.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/50/images/isleworth2.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/50/images/isleworth3.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void LoadAfrica(int id)
        {
            Project = App.ProjectsViewModel.AllProjects[id];
            Project.Description = "Created to serve the 5-star Safari Game Lodge tourist industry, Pamushana is arguably the most exclusive safari lodge in Zimbabwe. ATFA participated and coordinated a team of local and stateside designers and engineers to produce this exemplary lodge. The design consisted of an open reception and lounging area surrounding a reflective pool overseeing the panoramic views over the Malilangwe Lake. Nearby, the exterior bar and dining terraces, and the interior airconditioned dining room serve the guests that also oversee the magnificent views. A 5,000-bottle wine cellar serves as a central theme for the Dining Room. The lodge houses its guests in six individual private villas, separated by both the configuration of the site plan and the lush landscaping developed for the project. Each villa is designed as a private suite, with a large bedroom and bathroom. All the spaces have a small private pool, with independent and private views over the lake. Several amenities serve the guests, including a gun room, an archery range, a private gym and spa. The complex also supports all back of house needs for a game lodge.";

            var imageLinks = new Collection<Uri>
            {
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/39/images/img_1482.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/39/images/img_1491.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/39/images/img_1507.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/39/images/img_1513.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/39/images/img_1526.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/39/images/img_1647.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/39/images/img_1811.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/39/images/img_2033.jpg", UriKind.Absolute),
                new Uri("http://www.atfranco.com/wp-content/uploads/wow-slider-plugin/39/images/img_3995.jpg", UriKind.Absolute)
            };

            LoadProjectImages(imageLinks);
        }

        /// <summary>
        /// Loads all the images for this project from the internet or isolated storage using the provided uri's.
        /// </summary>
        /// <param name="imageLinks">The enumerable of uri's to attempt to load.</param>
        private void LoadProjectImages(ICollection<Uri> imageLinks)
        {
            var inMemoryImages = AppImages.Instance.Images;
            Project.Images = new ObservableCollection<BitmapImage>();

            _workload = imageLinks.Count;
            foreach (Uri uri in imageLinks)
            {
                string uriName = uri.Segments[uri.Segments.Length - 3].Substring(0, 2) + Path.GetFileName(uri.LocalPath);
                AppLoading.Instance.IsLoading = true;
                if (!inMemoryImages.ContainsKey(uriName))
                {
                    // Try get from isolated storage cache.
                    var bitmap = AppStorage.Instance.LoadTileImage(Project, uriName);
                    if (null == bitmap)
                    {
                        var missingImage = new BitmapImage { CreateOptions = _createOptions };
                        missingImage.SetValue(FrameworkElement.NameProperty, uriName);
                        missingImage.ImageOpened += this.ProjectImage_ImageOpened;
                        missingImage.ImageFailed += AppImages.Instance.Image_ImageFailed;
                        missingImage.UriSource = uri;
                    }
                    else
                    {
                        Project.Images.Add(bitmap);
                        inMemoryImages.Add((string)bitmap.GetValue(FrameworkElement.NameProperty), bitmap);
                        if (--_workload == 0)
                            OnFinished();
                        AppLoading.Instance.IsLoading = false;
                    }
                }
                else
                {
                    var bitmap = inMemoryImages[uriName];
                    Project.Images.Add(bitmap);
                    if (--_workload == 0)
                        OnFinished();
                    AppLoading.Instance.IsLoading = false;
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ProjectImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            // Crop the image.
            var cropped = CropImage((BitmapImage)sender);
            // Store cropped image in iso
            AppStorage.Instance.SaveTileImage(Project, cropped);
            // Save the image to the project.
            var bitmap = SaveProjectImage(cropped);
            // Save image to all app images.
            AppImages.Instance.Image_ImageOpened(bitmap, e);
            if (--_workload == 0)
                OnFinished();
        }

        /// <summary>
        /// Crops the image when it is finished downloading, and saves it to isolated storage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="rea"></param>
        private WriteableBitmap CropImage(BitmapImage source)
        {
            // Get source name
            string sourceName = (string)source.GetValue(FrameworkElement.NameProperty);

            // Crop image and preserve name
            var cropped = new WriteableBitmap(source);
            cropped = cropped.Crop(cropped.GetBounded(BORDER_THRESHOLD));
            cropped.SetValue(FrameworkElement.NameProperty, sourceName);
            return cropped;
        }

        /// <summary>
        /// Saves the image to the project and app memory.
        /// </summary>
        /// <param name="cropped"></param>
        /// <returns></returns>
        private BitmapImage SaveProjectImage(WriteableBitmap cropped)
        {
            // Convert cropped image to bitmap and save to project
            BitmapImage croppedBitmap = new BitmapImage();
            croppedBitmap.SetValue(FrameworkElement.NameProperty, (string)cropped.GetValue(FrameworkElement.NameProperty));
            using (MemoryStream croppedContents = new MemoryStream())
            {
                cropped.SaveJpeg(croppedContents, cropped.PixelWidth, cropped.PixelHeight, 0, 100);
                croppedBitmap.SetSource(croppedContents);
            }
            Project.Images.Add(croppedBitmap);
            return croppedBitmap;
        }

        protected virtual void OnFinished()
        {
            if (null != FinishedLoading)
            {
                FinishedLoading(this, new EventArgs());
            }
        }
    }
}