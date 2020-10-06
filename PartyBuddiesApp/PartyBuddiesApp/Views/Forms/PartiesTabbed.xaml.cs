using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartyBuddiesApp.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PartiesTabbed : TabbedPage
    {
        public PartiesTabbed()
        {
            InitializeComponent();
            this.SelectedTabColor = Color.Black;
            this.UnselectedTabColor = Color.White;
            this.BarBackgroundColor = Color.FromHex("#EF4873");
        }
    }
}