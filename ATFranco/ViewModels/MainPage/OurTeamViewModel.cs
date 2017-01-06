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
    using System.Windows;
    using System.Windows.Media.Imaging;

    internal class OurTeamViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> _employees;

        public OurTeamViewModel()
        {
            var kikoImage = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
            var kikoName = "Kiko.png";
            kikoImage.SetValue(FrameworkElement.NameProperty, kikoName);
            kikoImage.ImageOpened += AppImages.Instance.Image_ImageOpened;
            kikoImage.ImageFailed += AppImages.Instance.Image_ImageFailed;
            kikoImage.UriSource = new Uri("/Assets/Team/Kiko.png", UriKind.Relative);
            AppImages.Instance.DisallowedImages.Add(kikoName, kikoImage);
            AppLoading.Instance.IsLoading = true;

            var jonImage = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
            var jonName = "Jon.png";
            jonImage.SetValue(FrameworkElement.NameProperty, jonName);
            jonImage.ImageOpened += AppImages.Instance.Image_ImageOpened;
            jonImage.ImageFailed += AppImages.Instance.Image_ImageFailed;
            jonImage.UriSource = new Uri("/Assets/Team/Jon.png", UriKind.Relative);
            AppImages.Instance.DisallowedImages.Add(jonName, jonImage);
            AppLoading.Instance.IsLoading = true;

            var angelImage = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
            var angelName = "Angel.png";
            angelImage.SetValue(FrameworkElement.NameProperty, angelName);
            angelImage.ImageOpened += AppImages.Instance.Image_ImageOpened;
            angelImage.ImageFailed += AppImages.Instance.Image_ImageFailed;
            angelImage.UriSource = new Uri("/Assets/Team/Angel.png", UriKind.Relative);
            AppImages.Instance.DisallowedImages.Add(angelName, angelImage);
            AppLoading.Instance.IsLoading = true;

            Employees = new ObservableCollection<Employee>
            {
                new Employee
                {
                    Name = "Kiko",
                    Image = kikoImage,
                    Title = "ANGEL T FRANCO, AIA\nPRINCIPAL",
                    Description = "\tA native of Puerto Rico, Angel T. \"Kiko\" Franco, has a career that spans 34 years in the fields of architecture, planning, interior design and construction management and administration. He holds a Master's Degree in Architecture from the University of Puerto Rico.\n\n\tGrowing up in the tropics he was intrigued by how structures were affected by, and responded to, their natural environment and says this marked how he has approached every project as an architect.\n\n\tOne of his career's most memorable experiences was on his first trip to Africa where after traveling more than 27 hours by plane, he hiked to the top of a mountain to study the natural surroundings of the site and evaluate how the elements would play into the future design. Perched atop the hill for an entire day and night, he observed where the sun and moon rose and set in relation to the selected site; the different views from various angles and the natural rock formations that would later be incorporated into the design. This contemplative time defined how the project had to be approached, where the design components would be located, how they should respond to nature, and ultimately helped him implement a solution which resulted in a very successful project.\n\n\tKiko founded AT Franco & Associates in 1988 with the intention of providing a full-service architecture firm to clients looking for everything from design to construction administration and all aspects in between.\n\n\tHe has managed a large variety of architectural projects including safari lodges, golf clubhouses, luxury residences, hotels and schools in the United States and in various international locations including Africa, Australia, Bonaire (Netherland Antilles), Costa Rica, Venezuela and others. He has also participated in largescale planning and urban development projects in many of these locations.\n\n\tAs a member of the American Institute of Architects, he keeps up to date with the highest standards of the practice and maintains an updated NCARB certification. In 2007, the Governor of the State of Florida appointed him to the Florida Building Commission, where he still occupies the Architects' chair in the preparation of the Florida Building Code.\n\n\tKiko and his wife Mary Helen reside in Fort Lauderdale, Florida, where they enjoy spending time with their four sons and two beautiful grandchildren.\n\n\tFavorite building: Gugghenheim Museum – New York, New York – by Frank Lloyd Wright"
                },
                new Employee
                {
                    Name = "Jon",
                    Image = jonImage,
                    Title = "JON BONITA\nGRADUATE ARCHITECT\nASSOCIATE",
                    Description = "\tJon Bonita knew from a young age that he wanted to design and build. He loved working with his hands – from building blocks to landscaping – and felt a great sense of achievement in seeing his creations come to life. During his studies at Roger Williams University, Jon traveled to Rome for a semester and was in awe at the layers of living architectural history and urban planning and credits this experience for much of his inspiration.\n\n\tGrowing up in the tropics he was intrigued by how structures were affected by, and responded to, their natural environment and says this marked how he has approached every project as an architect.\n\n\tHe draws upon his experience as a plumber's apprentice during his college years, which allowed him to understand that the success of any project depends upon the careful coordination of all of the trades, each of them being equally important to the end result.\n\n\tJon has worked on a wide gamut of projects ranging from schools to commercial offices to luxury waterfront homes. He particularly enjoys historical renovation projects where he is challenged to preserve the architectural integrity of the structure, while incorporating modern elements to bring the design to present day. His favorite projects of this kind of have been waterfront homes in Miami, The Bahamas and New Hampshire. A native New Yorker and having lived in Miami for 10 years, Jon enjoys working with the different styles of architecture in both regions and climates.\n\n\tJon holds a Bachelor of Architecture from Roger Williams University in Bristol, Rhode Island. He resides in Wilton, Connecticut with his wife and three daughters, whom he loves to take to Home Depot.\n\n\tFavorite building: The chapel of Notre Dame du Haut \"Ronchamp\" – Haute-Saône, France – by Le Corbusier"
                },
                new Employee
                {
                    Name = "Angel",
                    Image = angelImage,
                    Title = "ANGEL FRANCO\nGRADUATE ARCHITECT\nASSOCIATE",
                    Description = "\tBorn to an architect, Angel spent much of his childhood touring jobsites and learning about architecture with his father, but it was not until he went to college that he decided to enroll in architecture courses and follow in his father's footsteps.\n\n\tAt Florida Atlantic University, Angel found himself most intrigued by architecture history and theory classes, and says it is from this that he draws his design inspiration. Early in his career, he spent much of his time building models, which he still enjoys.\n\n\tHis favorite part of any project is incorporating components that merge the boundaries between interior and exterior environments and making these transitions seamless.\n\n\tHe has spent a significant amount of time managing projects in Central America, and has enjoyed discovering that there are very specific ways through which cultures incorporate their own traditions in what is the visual, physical, and audible language of design.\n\n\tAngel holds a Bachelor of Architecture degree from Florida Atlantic University. He is a native Floridian and resides in Fort Lauderdale, FL. He enjoys cycling and participates in charity races to raise funds for organizations such as the Multiple Sclerosis Society and Kids in Distress.\n\n\tFavorite building: Jubilee Church – Rome, Italy – by Richard Meier"
                }
            };
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                OnPropertyChanging("Employees");
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }
    }
}