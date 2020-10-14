using PartyBuddiesApp.Views.Chat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
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
                IconImageSource = "@drawable/nonotifications.png",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                Command = new Command(this.NotificationsClicked)
            };
            ToolbarItem PartyBuddies = new ToolbarItem()
            {
                Text = "Party Buddies",
                //IconImageSource = ImageSource.FromResource("PartyBuddiesApp.Images.notofications.png", typeof(App).GetTypeInfo().Assembly),
                Order = ToolbarItemOrder.Primary,

                Priority = 1
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
                IconImageSource = "@drawable/messagelight.png",
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
            (App.Current.MainPage as NavigationPage).PushAsync(new Views.Chat.RecentChatPage());
        }


        private void NotificationsClicked(object obj)
        {
            (App.Current.MainPage as NavigationPage).PushAsync(new Views.Notification.SocialNotificationPage());
        }
        #endregion
    }
}
