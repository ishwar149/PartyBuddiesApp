using PartyBuddiesApp.Views.LoginAndRegister;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartyBuddiesApp
{
    public partial class App : Application
    {
        public App()
        {


            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzEyNDkyQDMxMzgyZTMyMmUzMGZJUmx3aE5LcW03S20xQkRwVTJCTDVuT1lIQlVTR2NiTyt4K1NabWlEL2M9");
            InitializeComponent();
            MainPage = new Views.LoginAndRegister.LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        
    }
}
