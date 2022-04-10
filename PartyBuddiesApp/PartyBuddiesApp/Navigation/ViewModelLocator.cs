using GalaSoft.MvvmLight.Ioc;
using PartyBuddiesApp.ViewModels;
using PartyBuddiesApp.ViewModels.Chat;
using PartyBuddiesApp.ViewModels.Forms;
using PartyBuddiesApp.ViewModels.LoginAndRegister;
using PartyBuddiesApp.ViewModels.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyBuddiesApp.Navigation
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {

            SimpleIoc.Default.Register<BaseViewModel>();

            SimpleIoc.Default.Register<ChatMessageViewModel>();
            SimpleIoc.Default.Register<RecentChatViewModel>();

            SimpleIoc.Default.Register<AddPartyPageViewModel>();
            SimpleIoc.Default.Register<PreferencesPageViewModel>();
            SimpleIoc.Default.Register<ProfilePageViewModel>();
            SimpleIoc.Default.Register<SwipeHomePageViewModel>();
            SimpleIoc.Default.Register<PartiesPageViewModel>();

            SimpleIoc.Default.Register<LoginPageViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<OtpPageViewModel>();
            SimpleIoc.Default.Register<SignUpPageViewModel>();

            SimpleIoc.Default.Register<SocialNotificationViewModel>();



        }

        public BaseViewModel BaseVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<BaseViewModel>())
                {
                    SimpleIoc.Default.Register<BaseViewModel>();
                }
                return SimpleIoc.Default.GetInstance<BaseViewModel>();
            }
        }


        public ChatMessageViewModel ChatMessageVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<ChatMessageViewModel>())
                {
                    SimpleIoc.Default.Register<ChatMessageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<ChatMessageViewModel>();
            }
        }

        public RecentChatViewModel RecentChatVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<RecentChatViewModel>())
                {
                    SimpleIoc.Default.Register<RecentChatViewModel>();
                }
                return SimpleIoc.Default.GetInstance<RecentChatViewModel>();
            }
        }


        public AddPartyPageViewModel AddPartyPageVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<AddPartyPageViewModel>())
                {
                    SimpleIoc.Default.Register<AddPartyPageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<AddPartyPageViewModel>();
            }
        }


        public PreferencesPageViewModel PreferencesPageVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<PreferencesPageViewModel>())
                {
                    SimpleIoc.Default.Register<PreferencesPageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<PreferencesPageViewModel>();
            }
        }


        public ProfilePageViewModel ProfilePageVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<ProfilePageViewModel>())
                {
                    SimpleIoc.Default.Register<ProfilePageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<ProfilePageViewModel>();
            }
        }


        public SwipeHomePageViewModel SwipeHomePageVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<SwipeHomePageViewModel>())
                {
                    SimpleIoc.Default.Register<SwipeHomePageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<SwipeHomePageViewModel>();
            }
        }

        public PartiesPageViewModel PartiesPageVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<PartiesPageViewModel>())
                {
                    SimpleIoc.Default.Register<PartiesPageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<PartiesPageViewModel>();
            }
        }

        public LoginPageViewModel LoginPageVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<LoginPageViewModel>())
                {
                    SimpleIoc.Default.Register<LoginPageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<LoginPageViewModel>();
            }
        }

        public LoginViewModel LoginVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<LoginViewModel>())
                {
                    SimpleIoc.Default.Register<LoginViewModel>();
                }
                return SimpleIoc.Default.GetInstance<LoginViewModel>();
            }
        }

        public OtpPageViewModel OtpPageVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<OtpPageViewModel>())
                {
                    SimpleIoc.Default.Register<OtpPageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<OtpPageViewModel>();
            }
        }

        public SignUpPageViewModel SignUpPageVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<SignUpPageViewModel>())
                {
                    SimpleIoc.Default.Register<SignUpPageViewModel>();
                }
                return SimpleIoc.Default.GetInstance<SignUpPageViewModel>();
            }
        }

        public SocialNotificationViewModel SocialNotificationVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<SocialNotificationViewModel>())
                {
                    SimpleIoc.Default.Register<SocialNotificationViewModel>();
                }
                return SimpleIoc.Default.GetInstance<SocialNotificationViewModel>();
            }
        }


    }
}
