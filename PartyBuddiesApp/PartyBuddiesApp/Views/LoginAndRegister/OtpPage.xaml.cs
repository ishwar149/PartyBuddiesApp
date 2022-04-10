using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartyBuddiesApp.Views.LoginAndRegister
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtpPage : ContentPage
    {

        public OtpPage(string email)
        {
            BindingContext = App.ViewModelLocator.OtpPageVM;
            InitializeComponent();
        }

    }
}