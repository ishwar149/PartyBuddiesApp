using Acr.UserDialogs;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.AspNetCore.SignalR.Client;
using PartyBuddiesApp.Navigation;
using PartyBuddiesApp.Views.LoginAndRegister;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartyBuddiesApp
{
    public partial class App : Application
    {
        private static ViewModelLocator _viewModelLocator;
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzEyNDkyQDMxMzgyZTMyMmUzMGZJUmx3aE5LcW03S20xQkRwVTJCTDVuT1lIQlVTR2NiTyt4K1NabWlEL2M9");

            //on token referesh Save Token to the Application Properties
            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) => UpdateFireBaseToken();
          
            //handle notifications
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                ViewModels.Notification.SocialNotificationViewModel viewmodel = ViewModelLocator.SocialNotificationVM;
                if (ViewModelLocator.SocialNotificationVM.RecentList != null)
                    ViewModelLocator.SocialNotificationVM.RecentList.Add(new Models.Notification.SocialNotificationModel() { Name = p.Data["UserEmail"].ToString(), ReceivedTime = "Now" });
                else
                {
                    ViewModelLocator.SocialNotificationVM.RecentList = new System.Collections.ObjectModel.ObservableCollection<Models.Notification.SocialNotificationModel>();
                    ViewModelLocator.SocialNotificationVM.RecentList.Add(new Models.Notification.SocialNotificationModel() { Name = p.Data["UserEmail"].ToString(), ReceivedTime = "Now" });
                }
            };
            InitializeComponent();
            SetMainPage();

        }

        public static ViewModelLocator ViewModelLocator
        {
            get { return _viewModelLocator ?? (_viewModelLocator = new ViewModelLocator()); }
        }
        public static double MessageStatus = 0;

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }

        protected void UpdateFireBaseToken()
        {
            if (!Application.Current.Properties.ContainsKey("Firebasetoken"))
            {
                Application.Current.Properties["Firebasetoken"] = CrossFirebasePushNotification.Current.Token;

            }
            else if (CrossFirebasePushNotification.Current.Token != Convert.ToString(Application.Current.Properties["Firebasetoken"]))
            {
                Application.Current.Properties["Firebasetoken"] = CrossFirebasePushNotification.Current.Token;
            }
        }

        protected void SetMainPage()
        {
            try
            {
                if (!Application.Current.Properties.ContainsKey("Firebasetoken"))
                {
                    Application.Current.Properties["Firebasetoken"] = CrossFirebasePushNotification.Current.Token;

                }

                if (!Application.Current.Properties.ContainsKey("email"))
                {
                    App.Current.MainPage = new Views.LoginAndRegister.LoginPage();
                }
                else if (!Application.Current.Properties.ContainsKey("otpverified"))
                {
                    App.Current.MainPage = new NavigationPage(new Views.LoginAndRegister.OtpPage(Convert.ToString(Application.Current.Properties["email"])));
                }
                else
                {
                    ViewModels.BaseViewModel baseViewModel = new ViewModels.BaseViewModel();
                    ViewModelLocator.BaseVM.SetTabbedHomePage();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert($"Not Working {ex.Message}, SetMainPage");
            }
        }

    }
}
