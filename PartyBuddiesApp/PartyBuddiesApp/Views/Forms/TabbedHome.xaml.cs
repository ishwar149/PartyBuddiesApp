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
            this.BackgroundColor = Color.Black;
            this.SelectedTabColor = Color.White;
            this.UnselectedTabColor = Color.White;
        }
    }
}