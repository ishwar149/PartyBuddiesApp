﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartyBuddiesApp.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPartyPage : ContentPage
    {
        public AddPartyPage()
        {
            BindingContext = App.ViewModelLocator.AddPartyPageVM;
            InitializeComponent();
        }
    }
}