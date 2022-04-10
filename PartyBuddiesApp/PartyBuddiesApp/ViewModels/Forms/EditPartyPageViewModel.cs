using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using PartyBuddiesAppDA.BusinessObjects;
using Acr.UserDialogs;
using Xamarin.Forms.Internals;

namespace PartyBuddiesApp.ViewModels.Forms
{
    /// <summary>
    /// View model for recent chat page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class EditPartyPageViewModel : BaseViewModel
    {
        #region Fields

        private string _partyType;
        private string _partyPlace;
        private string _buddyPrefrence;
        private decimal _longitude;
        private decimal _latitude;
        private string _partytime;
        private string _partyExpense;
        private string _nightAccomodation;
        private int _agePreferenceStart;
        private int _agePreferenceEnd;
        private DateTime _partyDate;
        private bool _updateEnabled;
        string ispermissiongranted = string.Empty;

        private string URL { get; set; }

        #endregion

        #region property

        public string PartyType
        {
            get
            {
                return this._partyType;
            }

            set
            {
                if (this._partyType == value)
                {
                    return;
                }

                this._partyType = value;
                this.NotifyPropertyChanged();
            }
        }



        public string PartyPlace
        {
            get
            {
                return this._partyPlace;
            }

            set
            {
                if (this._partyPlace == value)
                {
                    return;
                }

                this._partyPlace = value;
                this.NotifyPropertyChanged();
            }
        }


        public string BuddyPrefrence
        {
            get
            {
                return this._buddyPrefrence;
            }

            set
            {
                if (this._buddyPrefrence == value)
                {
                    return;
                }

                this._buddyPrefrence = value;
                this.NotifyPropertyChanged();
            }
        }


        public int AgePreferenceStart
        {
            get
            {
                return this._agePreferenceStart;
            }

            set
            {
                if (this._agePreferenceStart == value)
                {
                    return;
                }

                this._agePreferenceStart = value;
                this.NotifyPropertyChanged();
            }
        }


        public int AgePreferenceEnd
        {
            get
            {
                return this._agePreferenceEnd;
            }

            set
            {
                if (this._agePreferenceEnd == value)
                {
                    return;
                }

                this._agePreferenceEnd = value;
                this.NotifyPropertyChanged();
            }
        }


        public decimal Longitude
        {
            get
            {
                return this._longitude;
            }

            set
            {
                if (this._longitude == value)
                {
                    return;
                }

                this._longitude = value;
                this.NotifyPropertyChanged();
            }
        }


        public decimal Latitude
        {
            get
            {
                return this._latitude;
            }

            set
            {
                if (this._latitude == value)
                {
                    return;
                }

                this._latitude = value;
                this.NotifyPropertyChanged();
            }
        }


        public DateTime PartyDate
        {
            get
            {
                return this._partyDate;
            }

            set
            {
                if (this._partyDate == value)
                {
                    return;
                }

                this._partyDate = value;
                this.NotifyPropertyChanged();
            }
        }

        public DateTime MinimumDate
        {
            get
            {
                return System.DateTime.Now.Date;
            }
        }


        public string PartyTime
        {
            get
            {
                return this._partytime;
            }

            set
            {
                if (this._partytime == value)
                {
                    return;
                }

                this._partytime = value;
                this.NotifyPropertyChanged();
            }
        }
        public string PartyExpence
        {
            get
            {
                return this._partyExpense;
            }

            set
            {
                if (this._partyExpense == value)
                {
                    return;
                }

                this._partyExpense = value;
                this.NotifyPropertyChanged();
            }
        }

        public string NightAccomodation
        {
            get
            {
                return this._nightAccomodation;
            }

            set
            {
                if (this._nightAccomodation == value)
                {
                    return;
                }

                this._nightAccomodation = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool UpdateEnabled
        {
            get
            {
                return this._updateEnabled;
            }

            set
            {
                if (this._updateEnabled == value)
                {
                    return;
                }

                this._updateEnabled = value;
                this.NotifyPropertyChanged();
            }
        }


        #endregion

        #region constructor
        public EditPartyPageViewModel()
        {
            UpdateEnabled = true;
            BindLocation();
            BindButtonClicks();
            BindParty();

        }

        private void BindParty()
        {

        }
        private void BindLocation()
        {
            var LocationWhenInUse = Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (LocationWhenInUse.Result == PermissionStatus.Denied || LocationWhenInUse.Result == PermissionStatus.Unknown)
                GetLocationPermission();
            else if (LocationWhenInUse.Result == PermissionStatus.Granted || !string.IsNullOrEmpty(ispermissiongranted))
            {
                Task<Location> location = Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    location = Geolocation.GetLocationAsync(request);
                }
                if (location != null)
                {
                    Latitude = Convert.ToDecimal(location.Result.Latitude);
                    Longitude = Convert.ToDecimal(location.Result.Longitude);
                }
            }
        }

        private void BindButtonClicks()
        {
            this.UpdateParty = new Command(this.UpdatePartyClicked);
            this.PartyTypeChangeCommand = new Command(this.PartyTypeChangeClicked);
            this.PartyPlaceChangeCommand = new Command(this.PartyPlaceChangeClicked);
            this.BuddyPreferenceChangeCommand = new Command(this.BuddyPreferenceChangeClicked);
            this.PartyExpenceChangeCommand = new Command(this.PartyExpenceChangeClicked);
            this.NightAccomodationChangeCommand = new Command(this.NightAccomodationChangeClicked);
        }

        public async void GetLocationPermission()
        {
            var permissionStatus = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (permissionStatus == PermissionStatus.Granted)
                ispermissiongranted = "Yes";
        }

        #endregion

        #region Commands
        public Command UpdateParty { get; set; }

        public Command PartyTypeChangeCommand { get; set; }

        public Command PartyPlaceChangeCommand { get; set; }

        public Command BuddyPreferenceChangeCommand { get; set; }

        public Command PartyExpenceChangeCommand { get; set; }

        public Command NightAccomodationChangeCommand { get; set; }

        #endregion

        #region Command Clicks
        private async void UpdatePartyClicked(object obj)
        {
            UpdateEnabled = false;
            UserDialogs.Instance.ShowLoading("Adding Party Please Wait...");
            await Task.Delay(200);
            Party party = new Party();
            party.PartyTime = PartyTime;
            party.PartyAlcoholic = PartyType;
            party.BuddyGenderPreference = BuddyPrefrence;
            party.IsNightAccomodation = NightAccomodation;
            party.PartyPlace = PartyPlace;
            party.IsPartyExpenseShared = PartyExpence;
            party.BuddyMinAgePreference = AgePreferenceStart;
            party.BuddyMaxAgePreference = AgePreferenceEnd;
            party.PartyLongitude = Longitude;
            party.PartyLatitude = Latitude;
            party.PartyDateString = PartyDate.Date.ToString();
            PartyBuddiesAppDA.DataAccess.PartyDA.Add(party);
            UserDialogs.Instance.HideLoading();
            UserDialogs.Instance.Alert("Party Added Successfully", "Party Added", "Ok");

        }




        private void PartyTypeChangeClicked(object obj)
        {
            var sfradionbutton = obj as Syncfusion.XForms.Buttons.SfRadioButton;
            if (sfradionbutton.IsChecked == true)
                PartyType = sfradionbutton.Text;
        }

        private void PartyPlaceChangeClicked(object obj)
        {
            var sfradionbutton = obj as Syncfusion.XForms.Buttons.SfRadioButton;
            if (sfradionbutton.IsChecked == true)
                PartyPlace = sfradionbutton.Text;
        }

        private void BuddyPreferenceChangeClicked(object obj)
        {
            var sfradionbutton = obj as Syncfusion.XForms.Buttons.SfRadioButton;
            if (sfradionbutton.IsChecked == true)
                BuddyPrefrence = sfradionbutton.Text;
        }

        private void PartyExpenceChangeClicked(object obj)
        {
            var sfradionbutton = obj as Syncfusion.XForms.Buttons.SfRadioButton;
            if (sfradionbutton.IsChecked == true)
                PartyExpence = sfradionbutton.Text;
        }

        private void NightAccomodationChangeClicked(object obj)
        {
            var sfradionbutton = obj as Syncfusion.XForms.Buttons.SfRadioButton;
            if (sfradionbutton.IsChecked == true)
                NightAccomodation = sfradionbutton.Text;
        }



        #endregion
    }
}
