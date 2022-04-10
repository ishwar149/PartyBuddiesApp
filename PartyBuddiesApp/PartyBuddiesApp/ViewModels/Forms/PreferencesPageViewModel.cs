using Acr.UserDialogs;
using PartyBuddiesAppDA.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PartyBuddiesApp.ViewModels.Forms
{
    /// <summary>
    /// View model for recent chat page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class PreferencesPageViewModel : BaseViewModel
    {
        #region Fields

        private string _partyType;
        private string _partyPlace;
        private string _buddyPrefrence;
        private string _partytime;
        private string _partyExpense;
        private string _nightAccomodation;
        private int _agePreferenceStart;
        private int _agePreferenceEnd;
        private int _distance;

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

        public int Distance
        {
            get
            {
                return this._distance;
            }

            set
            {
                if (this._distance == value)
                {
                    return;
                }

                this._distance = value;
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

        #endregion

        #region constructor
        public PreferencesPageViewModel()
        {

            // Get Preferences and Bind
            BindPreferences();
            this.SavePreferences = new Command(this.SavePreferencesClicked);
            this.PartyTypeChangeCommand = new Command(this.PartyTypeChangeClicked);
            this.PartyPlaceChangeCommand = new Command(this.PartyPlaceChangeClicked);
            this.BuddyPreferenceChangeCommand = new Command(this.BuddyPreferenceChangeClicked);
            this.PartyExpenceChangeCommand = new Command(this.PartyExpenceChangeClicked);
            this.NightAccomodationChangeCommand = new Command(this.NightAccomodationChangeClicked);

        }
        #endregion

        #region Commands
        public Command SavePreferences { get; set; }

        public Command PartyTypeChangeCommand { get; set; }

        public Command PartyPlaceChangeCommand { get; set; }

        public Command BuddyPreferenceChangeCommand { get; set; }

        public Command PartyExpenceChangeCommand { get; set; }


        public Command NightAccomodationChangeCommand { get; set; }




        #endregion

        #region Command Clicks
        private async void SavePreferencesClicked(object obj)
        {
            UserDialogs.Instance.ShowLoading("Saving Preferences...");
            await Task.Delay(200);
            PartyPreferences partyPreference = new PartyPreferences();
            partyPreference.PartyTime = PartyTime;
            partyPreference.PartyTypeAlcoholic = PartyType;
            partyPreference.PartyBuddyPreference = BuddyPrefrence;
            partyPreference.NightAccomodation = NightAccomodation;
            partyPreference.PartyPlace = PartyPlace;
            partyPreference.PartyExpense = PartyExpence;
            partyPreference.PartyBuddyMinAge = AgePreferenceStart;
            partyPreference.PartyBuddyMaxAge = AgePreferenceEnd;
            partyPreference.PartyDistance = Distance;
            PartyBuddiesAppDA.DataAccess.PartyPreferencesDA.Add(partyPreference);
            UserDialogs.Instance.HideLoading();
            UserDialogs.Instance.Alert("Your Preferences has been Saved.", "Preferences Saved", "Ok");
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


        #region Helper Methods

        private void BindPreferences()
        {
            PartyPreferences partyPreference = PartyBuddiesAppDA.DataAccess.PartyPreferencesDA.GetUserPreferences();
            if (partyPreference != null)
            {
                //Bind values
                PartyTime = partyPreference.PartyTime;
                PartyType = partyPreference.PartyTypeAlcoholic;
                BuddyPrefrence = partyPreference.PartyBuddyPreference;
                NightAccomodation = partyPreference.NightAccomodation;
                PartyPlace = partyPreference.PartyPlace;
                PartyExpence = partyPreference.PartyExpense;
                AgePreferenceStart = partyPreference.PartyBuddyMinAge.Value;
                AgePreferenceEnd = partyPreference.PartyBuddyMaxAge.Value;
                Distance = partyPreference.PartyDistance.Value;
            }
            else
                Distance = 20;
        }

        #endregion
    }
}
