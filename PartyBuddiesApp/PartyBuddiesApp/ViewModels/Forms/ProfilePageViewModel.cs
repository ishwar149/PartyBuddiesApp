using PartyBuddiesAppDA.BusinessObjects;
using PartyBuddiesAppDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace PartyBuddiesApp.ViewModels.Forms
{
    /// <summary>
    /// View model for recent chat page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class ProfilePageViewModel : BaseViewModel
    {
        #region Fields

        private string name;
        private string dateofbirth;
        private string location;
        private string sex;
        private int partieshosted;
        private int tourshosted;
        private MediaFile _mediaFile;
        private string URL { get; set; }

        private ObservableCollection<UserImage> _userImages { get; set; }

        #endregion


        #region property


        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public ObservableCollection<UserImage> UserImages
        {
            get
            {
                return this._userImages;
            }

            set
            {
                if (this._userImages == value)
                {
                    return;
                }

                this._userImages = value;
                this.NotifyPropertyChanged();
            }
        }



        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.NotifyPropertyChanged();
            }
        }



        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string DateOfBirth
        {
            get
            {
                return this.dateofbirth;
            }

            set
            {
                if (this.dateofbirth == value)
                {
                    return;
                }

                this.dateofbirth = value;
                this.NotifyPropertyChanged();
            }
        }



        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                if (this.location == value)
                {
                    return;
                }

                this.location = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Sex
        {
            get
            {
                return this.sex;
            }

            set
            {
                if (this.sex == value)
                {
                    return;
                }

                this.sex = value;
                this.NotifyPropertyChanged();
            }
        }




        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public int PartiesHosted
        {
            get
            {
                return this.partieshosted;
            }

            set
            {
                if (this.partieshosted == value)
                {
                    return;
                }

                this.partieshosted = value;
                this.NotifyPropertyChanged();
            }
        }




        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public int ToursHosted
        {
            get
            {
                return this.tourshosted;
            }

            set
            {
                if (this.tourshosted == value)
                {
                    return;
                }

                this.tourshosted = value;
                this.NotifyPropertyChanged();
            }
        }
        #endregion

        #region constructor
        public ProfilePageViewModel()
        {
            App.MessageStatus = 4.5;
            this.UploadImagesCommand = new Command(this.UploadImagesClicked);
            this.LogOutCommand = new Command(this.LogOutClicked);
            UserProfile profile = UserProfileDA.GetUserProfile();
            Name = profile.Name;
            DateOfBirth = profile.DateOfBirth;
            Location = profile.Location;
            Sex = profile.Sex;
            PartiesHosted = 20;
            ToursHosted = 10;
            UserImages = UserImageDA.GetImages();
            App.MessageStatus = 4.6;
        }
        #endregion


        #region Commands
        public Command UploadImagesCommand { get; set; }

        public Command LogOutCommand { get; set; }


        #endregion

        #region Command Clicks
        private async void UploadImagesClicked(object obj)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Small,
                    CompressionQuality = 40,
                    CustomPhotoSize = 35
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;
                UserImageDA.UploadImages(_mediaFile);
                UserImages = UserImageDA.GetImages();
            }

        }

        private void LogOutClicked(object obj)
        {
            Application.Current.Properties.Remove("email");
            Application.Current.Properties.Remove("otpverified");
            App.Current.MainPage = new Views.LoginAndRegister.LoginPage();
        }


        #endregion
    }
}
