﻿using Acr.UserDialogs;
using GalaSoft.MvvmLight.Views;
using PartyBuddiesApp.Models.Notification;
using Plugin.FirebasePushNotification;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PartyBuddiesApp.ViewModels.Notification
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SocialNotificationViewModel : BaseViewModel
    {
        #region Fields
        private INavigationService _navigationService;
        private Command<object> itemTappedCommand;

        private Command<object> backCommand;

        private Command<object> menuCommand;

        private ObservableCollection<SocialNotificationModel> _recentList;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SocialNotificationViewModel"/> class.
        /// </summary>
        public SocialNotificationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.ItemSelected));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> BackCommand
        {
            get
            {
                return this.backCommand ?? (this.backCommand = new Command<object>(this.BackButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> MenuCommand
        {
            get
            {
                return this.menuCommand ?? (this.menuCommand = new Command<object>(this.MenuButtonClicked));
            }
        }

        public ObservableCollection<SocialNotificationModel> RecentList
        {
            get { return _recentList; }
            set
            {
                _recentList = value;
                this.NotifyPropertyChanged();
            }
        }


        public ObservableCollection<SocialNotificationModel> EarlierList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the navigation list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void ItemSelected(object selectedItem)
        {
            ((selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs)?.ItemData as SocialNotificationModel).IsRead = true;
            // Do something
        }

        /// <summary>
        /// Invoked when back button is clicked in the social notification page.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void BackButtonClicked(object obj)
        {
            _navigationService.GoBack();
            //(App.Current.MainPage as NavigationPage).PopAsync();
        }

        /// <summary>
        /// Invoked when menu button is clicked in the social notification page.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void MenuButtonClicked(object obj)
        {
            // Do something
        }

        #endregion

    }
}
