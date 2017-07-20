using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FlagData
{
    /// <summary>
    /// This model object represents a single flag
    /// </summary>
    public class Flag : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private string _country;
        
        /// <summary>
        /// Name of the country that this flag belongs to
        /// </summary>
        public string Country {
            get {return _country; }
            set
            { ChangePropertyValue(ref _country, value); }
        }

        private string _imageURL;
        
        /// <summary>
        /// Image URL for the flag (from resources)
        /// </summary>
        public string ImageUrl {
            get { return _imageURL; }
            set { ChangePropertyValue(ref _imageURL, value); }
        }

        private DateTime _dateAdopted;
        
        /// <summary>
        /// The date this flag was adopted
        /// </summary>
        public DateTime DateAdopted {
            get { return _dateAdopted; }
            set
            {
                if (_dateAdopted != value)
                {
                    _dateAdopted = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool _includesShield;

        /// <summary>
        /// Whether the flag includes an image/shield as part of the design
        /// </summary>
        public bool IncludesShield {
            get { return _includesShield; }
            set { ChangePropertyValue(ref _includesShield, value); }
        }

        private string _description;

        /// <summary>
        /// Some trivia or commentary about the flag
        /// </summary>
        public string Description {
            get { return _description; }
            set { ChangePropertyValue(ref _description, value); }
        }

        private Uri _moreInformationUrl;

        /// <summary>
        /// A URL for more information
        /// </summary>
        public Uri MoreInformationUrl
        {
            get { return _moreInformationUrl; }
            set { ChangePropertyValue(ref _moreInformationUrl, value); }
        }
        
        /// </summary>
        /// <typeparam name="T">Type being changed</typeparam>
        /// <param name="field">Field</param>
        /// <param name="value">New value</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>True if the value was changed.</returns>
        private bool ChangePropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (!Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Raises the INotifyPropertyChanged event.
        /// </summary>
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
