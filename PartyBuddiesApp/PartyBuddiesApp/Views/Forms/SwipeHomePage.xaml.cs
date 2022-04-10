using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartyBuddiesApp.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeHomePage : ContentPage
    {
        public SwipeHomePage()
        {
            InitializeComponent();
            BindingContext = App.ViewModelLocator.SwipeHomePageVM;
        }

    }

}