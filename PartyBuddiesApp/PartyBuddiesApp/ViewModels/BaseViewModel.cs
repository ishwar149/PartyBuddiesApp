using Acr.UserDialogs;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client;
using PartyBuddiesApp.Models.Notification;
using PartyBuddiesApp.Navigation;
using PartyBuddiesApp.Views.Chat;
using PartyBuddiesApp.Views.LoginAndRegister;
using PartyBuddiesAppDA.BusinessObjects;
using Plugin.FirebasePushNotification;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PartyBuddiesApp.ViewModels
{
    /// <summary>
    /// This viewmodel extends in another viewmodels.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class BaseViewModel : INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        #region Properties
        private static string _email { get; set; }

        public static string Email
        {
            get
            {
                if (string.IsNullOrEmpty(_email))
                    _email = Convert.ToString(Application.Current.Properties["email"]);
                return _email;
            }
        }



        #endregion

        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected void AddToolbarItems(Page MainPage)
        {

            ToolbarItem notification = new ToolbarItem()
            {
                Text = "Notifications",
                IconImageSource = "@drawable/notifications.png",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                Command = new Command(this.NotificationsClicked)
            };
            ToolbarItem PartyBuddies = new ToolbarItem()
            {
                Text = "Party Buddies",
                Order = ToolbarItemOrder.Primary,
                Priority = 1,
            };


            ToolbarItem item1 = new ToolbarItem()
            {
                Text = "",
                //IconImageSource = ImageSource.FromResource("PartyBuddiesApp.Images.notofications.png", typeof(App).GetTypeInfo().Assembly),
                Order = ToolbarItemOrder.Primary,
                Priority = 2
            };
            ToolbarItem item2 = new ToolbarItem()
            {
                Text = "",
                //IconImageSource = ImageSource.FromResource("PartyBuddiesApp.Images.notofications.png", typeof(App).GetTypeInfo().Assembly),
                Order = ToolbarItemOrder.Primary,
                Priority = 3
            };
            ToolbarItem item3 = new ToolbarItem()
            {
                Text = "",
                //IconImageSource = ImageSource.FromResource("PartyBuddiesApp.Images.notofications.png", typeof(App).GetTypeInfo().Assembly),
                Order = ToolbarItemOrder.Primary,
                Priority = 4
            };



            ToolbarItem Messages = new ToolbarItem()
            {
                Text = "Messages",
                IconImageSource = "@drawable/messagedark.png",
                Order = ToolbarItemOrder.Primary,
                Priority = 5,
                Command = new Command(this.MessagesClicked)

            };

            MainPage.ToolbarItems.Add(notification);
            MainPage.ToolbarItems.Add(PartyBuddies);
            MainPage.ToolbarItems.Add(item1);
            MainPage.ToolbarItems.Add(item2);
            MainPage.ToolbarItems.Add(item3);
            MainPage.ToolbarItems.Add(Messages);


        }



        private void MessagesClicked(object obj)
        {
            //(App.Current.MainPage as NavigationPage).PushAsync(new Views.Common.ComingSoonPage());
            (App.Current.MainPage as NavigationPage).PushAsync(new Views.Chat.RecentChatPage());
        }


        private void NotificationsClicked(object obj)
        {
            _navigationService.NavigateTo(Locator.SocialNotificationPage);
        }



        public static UserToken GetToken(IRestResponse response)
        {
            JsonDeserializer deserial = new JsonDeserializer();
            return deserial.Deserialize<UserToken>(response);
        }

        protected void UpdateFireBaseToken()
        {
            if (CrossFirebasePushNotification.Current.Token == "")
            {
                CrossFirebasePushNotification.Current.RegisterForPushNotifications();
            }

            if (!Application.Current.Properties.ContainsKey("Firebasetoken"))
            {
                Application.Current.Properties["Firebasetoken"] = CrossFirebasePushNotification.Current.Token;
                PartyBuddiesAppDA.DataAccess.UserProfileDA.UpdateFireBaseToken(Email, CrossFirebasePushNotification.Current.Token);

            }
            else if (CrossFirebasePushNotification.Current.Token != Convert.ToString(Application.Current.Properties["Firebasetoken"]))
            {
                Application.Current.Properties["Firebasetoken"] = CrossFirebasePushNotification.Current.Token;
                PartyBuddiesAppDA.DataAccess.UserProfileDA.UpdateFireBaseToken(Email, CrossFirebasePushNotification.Current.Token);
            }
        }


        public void SetTabbedHomePage()
        {
            try
            {
                //Set Navigation Service
                NavigationPage page = SetNavigation();
                App.MessageStatus = 7;
                App.Current.MainPage = page;
                App.MessageStatus = 8;
                AddToolbarItems(App.Current.MainPage);
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert($"Not Working {ex.Message},{ex.StackTrace},{ex.InnerException}, LoginClicked,{App.MessageStatus}");
            }
        }


        public NavigationPage SetNavigation()
        {
            if (!SimpleIoc.Default.IsRegistered<INavigationService>("nav"))
            {
                App.MessageStatus = 4;
                var nav = new NavigationService();
                nav.Configure(Locator.LoginPage, typeof(LoginPage));
                nav.Configure(Locator.OtpPage, typeof(OtpPage));
                nav.Configure(Locator.SignUpPage, typeof(SignUpPage));
                nav.Configure(Locator.TabbedHome, typeof(Views.Forms.TabbedHome));
                nav.Configure(Locator.SocialNotificationPage, typeof(Views.Notification.SocialNotificationPage));
                nav.Configure(Locator.comingSoonPage, typeof(Views.Common.ComingSoonPage));
                SimpleIoc.Default.Register<INavigationService>(() => nav);
                App.MessageStatus = 4.1;
                NavigationPage firstPage = new NavigationPage(new Views.Forms.TabbedHome())
                {
                    BarBackgroundColor = Color.Silver,
                };
                App.MessageStatus = 5;
                nav.Initialize(firstPage);
                App.MessageStatus = 6;
                _navigationService = nav;
                return firstPage;
            }
            else
            {
                NavigationPage firstPage = new NavigationPage(new Views.Forms.TabbedHome())
                {
                    BarBackgroundColor = Color.Silver,
                };
                return firstPage;
            }


        }


        #region SignalR
        public async void SignalRChatSetup()
        {
            using (var hubConnection = new Microsoft.AspNet.SignalR.Client.HubConnection("http://192.168.1.106:45455/"))
            {
                IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("ChatHub");
                stockTickerHubProxy.On<string, string>("SendChatMessage", (user, message) =>
                    {
                        var receivedMessage = $"{user} says {message}";
                    });
                await hubConnection.Start();
            }

        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //public async Task SignalRSendMessage(string user, string message)
        //{
        //    try
        //    {
        //        await hubConnection.InvokeAsync("SendChatMessage", user, message);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Send failed. Fail graciously.
        //    }
        //}

        #endregion

        #endregion
    }
}
