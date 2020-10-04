using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace PartyBuddiesApp.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedHome : Xamarin.Forms.TabbedPage
    {
        public TabbedHome()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
            this.SelectedTabColor = Color.Black;
            this.UnselectedTabColor = Color.White;
            this.BarBackgroundColor = Color.FromHex("#F24A67");
        }
    }
}