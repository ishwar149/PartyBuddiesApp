using PartyBuddiesAppDA.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PartyBuddiesApp.ViewModels.Forms
{
    /// <summary>
    /// View model for recent chat page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class PartiesPageViewModel : BaseViewModel
    {
        ObservableCollection<Party> futureparties;
        public ObservableCollection<Party> FuturePartiesList
        {
            get { return futureparties; }
            set { futureparties = value; NotifyPropertyChanged(); }
        }

        ObservableCollection<Party> pastparties;
        public ObservableCollection<Party> PastPartiesList
        {
            get { return pastparties; }
            set { pastparties = value; NotifyPropertyChanged(); }
        }

        public PartiesPageViewModel()
        {
            BindParties();
        }

        private void BindParties()
        {
            try
            {
                List<Party> parties = PartyBuddiesAppDA.DataAccess.PartyDA.GetUserParties();
                futureparties = new ObservableCollection<Party>();
                pastparties = new ObservableCollection<Party>(); ;
                foreach (Party party in parties)
                {
                    if (Convert.ToDateTime(party.PartyDate) < System.DateTime.Now)
                    {
                        PastPartiesList.Add(party);

                    }
                    else
                    {
                        FuturePartiesList.Add(party);
                        party.EditPartyCommand = new Command(this.EditPartyClicked);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }


        #region commands
        public Command EditPartyCommand { get; set; }
        #endregion


        #region CommandClicks
        private async void EditPartyClicked(object obj)
        {

        }
        #endregion
    }
}
