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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// TODO
    /// </summary>
    internal class ProjectsViewModel : ViewModelBase
    {
        private ObservableCollection<Project> _residentialProjects;
        private ObservableCollection<Project> _institutionalProjects;
        private ObservableCollection<Project> _leisureResortProjecs;
        private ObservableCollection<Project> _specialtyProjects;
        private ObservableCollection<Project> _allProjects;

        /// <summary>
        /// TODO
        /// </summary>
        public ProjectsViewModel()
        {
            // Assign Id's too projects.
            ResidentialProjects = new ObservableCollection<Project>
            {
                new Project { Id = 0, Title = "Private Residence", Location = "Miami Beach, FL", Type = ProjectClassification.Residential },
                new Project { Id = 1, Title = "Private Residence", Location = "Boca Raton, FL", Type = ProjectClassification.Residential },
                new Project { Id = 2, Title = "Private Residence", Location = "Islamorada, FL", Type = ProjectClassification.Residential },
                new Project { Id = 3, Title = "Private Residence", Location = "Abaco Islands, Bahamas", Type = ProjectClassification.Residential },
                new Project { Id = 4, Title = "Private Residence", Location = "Star Island, Miami Beach, FL", Type = ProjectClassification.Residential },
                new Project { Id = 5, Title = "Private Residence", Location = "Fort Lauderdale, FL", Type = ProjectClassification.Residential },
                new Project { Id = 6, Title = "Private Residence", Location = "Portsmouth, NH", Type = ProjectClassification.Residential }
            };
            InstitutionalProjects = new ObservableCollection<Project>
            {
                new Project { Id = 7, Title = "Cardinal Gibbons High School – Fort Lauderdale, FL", Type = ProjectClassification.Institutional },
                new Project { Id = 8, Title = "Jois Yoga", Type = ProjectClassification.Institutional }
            };
            LeisureResortProjects = new ObservableCollection<Project>
            {
                new Project { Id = 9, Title = "Adios Golf Club", Location = "Coconut Creek, FL", Type = ProjectClassification.LeisureAndResort },
                new Project { Id = 10, Title = "Broken Sound Clubhouse", Location = "Boca Raton, FL", Type = ProjectClassification.LeisureAndResort },
                new Project { Id = 11, Title = "Harbour Village Resort", Location = "Bonaire, Netherland Antilles", Type = ProjectClassification.LeisureAndResort },
                new Project { Id = 12, Title = "Isleworth Clubhouse", Location = "Windmere, FL", Type = ProjectClassification.LeisureAndResort }
            };
            SpecialtyProjects = new ObservableCollection<Project>
            {
                new Project { Id = 13, Title = "Pamushana Safari Camp", Location = "Zimbabwe, Africa", Type = ProjectClassification.Specialty }
            };
            AllProjects = new ObservableCollection<Project>();
            foreach (Project project in ResidentialProjects)
                AllProjects.Add(project);
            foreach (Project project in InstitutionalProjects)
                AllProjects.Add(project);
            foreach (Project project in LeisureResortProjects)
                AllProjects.Add(project);
            foreach (Project project in SpecialtyProjects)
                AllProjects.Add(project);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<Project> ResidentialProjects
        {
            get { return _residentialProjects; }
            set
            {
                OnPropertyChanging("ResidentialProjects");
                _residentialProjects = value;
                OnPropertyChanged("ResidentialProjects");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<Project> InstitutionalProjects
        {
            get { return _institutionalProjects; }
            set
            {
                OnPropertyChanging("InstitutionalProjects");
                _institutionalProjects = value;
                OnPropertyChanged("InstitutionalProjects");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<Project> LeisureResortProjects
        {
            get { return _leisureResortProjecs; }
            set
            {
                OnPropertyChanging("LeisureResortProjects");
                _leisureResortProjecs = value;
                OnPropertyChanged("LeisureResortProjects");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<Project> SpecialtyProjects
        {
            get { return _specialtyProjects; }
            set
            {
                OnPropertyChanging("SpecialtyProjects");
                _specialtyProjects = value;
                OnPropertyChanged("SpecialtyProjects");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ObservableCollection<Project> AllProjects
        {
            get { return _allProjects; }
            set
            {
                OnPropertyChanging("AllProjects");
                _allProjects = value;
                OnPropertyChanged("AllProjects");
            }
        }
    }
}
