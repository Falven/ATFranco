using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATFranco.Models
{
    /// <summary>
    /// An ATFranco Press attention or Award receieved.
    /// </summary>
    public class Publicity : PropertyNotificationBase, IBrowsable
    {
        private string _title;
        private string _description;
        private Uri _uri;

        /// <summary>
        /// The title of this publicity.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                OnPropertyChanging("Title");
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// The description for this publicity.
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
        public Uri Uri
        {
            get { return _uri; }
            set
            {
                if (value != _uri)
                {
                    OnPropertyChanging("Uri");
                    _uri = value;
                    OnPropertyChanged("Uri");
                }
            }
        }
    }
}
