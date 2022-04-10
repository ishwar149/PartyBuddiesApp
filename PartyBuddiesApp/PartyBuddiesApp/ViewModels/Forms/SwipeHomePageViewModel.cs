using PartyBuddiesAppDA.BusinessObjects;
using PartyBuddiesAppDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PartyBuddiesApp.ViewModels.Forms
{
    /// <summary>
    /// View model for recent chat page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class SwipeHomePageViewModel : BaseViewModel
    {
        ObservableCollection<SwipeHomeModel> parties;
        public ObservableCollection<SwipeHomeModel> Parties
        {
            get { return parties; }
            set { parties = value; NotifyPropertyChanged(); }
        }

        public SwipeHomePageViewModel()
        {
            App.MessageStatus = 4.2;
            this.SwipedLeft = new Command(this.SwipedLeftClicked);
            this.SwipedRight = new Command(this.SwipedRightClicked);
            App.MessageStatus = 4.3;
            BindParties();
            App.MessageStatus = 4.5;
        }


        public Command SwipedLeft { get; set; }

        public Command SwipedRight { get; set; }


        #region Command Clicks
        private void SwipedLeftClicked(object obj)
        {
            SwipeHomeModel userSwipe = obj as SwipeHomeModel;
            UserSwipeDA.Add(ConvertSwipeHomeModelToUserSwipe(userSwipe, "No"));
            if (Parties.Count < 1)
                BindParties();
        }

        private void SwipedRightClicked(object obj)
        {
            SwipeHomeModel userSwipe = obj as SwipeHomeModel;
            UserSwipeDA.Add(ConvertSwipeHomeModelToUserSwipe(userSwipe, "Yes"));
            if (Parties.Count < 1)
                BindParties();
        }


        private UserSwipe ConvertSwipeHomeModelToUserSwipe(SwipeHomeModel swipehome, string userAction)
        {
            return new UserSwipe() { UserAction = userAction, OrganiserEmail = swipehome.OrganiserEmail, PartyID = swipehome.PartyID, FireBaseToken = swipehome.FireBaseToken };
        }


        private void BindParties()
        {
            parties = PartyBuddiesAppDA.DataAccess.PartyDA.GetParties();
            App.MessageStatus = 4.4;
        }
        #endregion
    }
}
