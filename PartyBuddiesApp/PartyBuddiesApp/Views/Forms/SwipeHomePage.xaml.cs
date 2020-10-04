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
            BindingContext = new MainViewModel();
        }

    }
    public class MainViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Party> parties;
        public ObservableCollection<Party> Parties
        {
            get { return parties; }
            set { parties = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            parties = new ObservableCollection<Party>();
            parties.Add(new Party() { OrganiserName = "Ishwar", Date = "10 OCT 2020", IsAlcoholic = "Yes", Location = "Bathinda", Sex = "Any", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Image_created_with_a_mobile_phone.png/1200px-Image_created_with_a_mobile_phone.png" });
            parties.Add(new Party() { OrganiserName = "Ishwar", Date = "10 OCT 2020", IsAlcoholic = "Yes", Location = "Bathinda", Sex = "Any", ImageUrl = "https://miro.medium.com/max/1200/1*mk1-6aYaf_Bes1E3Imhc0A.jpeg" });
            parties.Add(new Party() { OrganiserName = "Ishwar", Date = "10 OCT 2020", IsAlcoholic = "Yes", Location = "Bathinda", Sex = "Any", ImageUrl = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__340.jpg" });
            parties.Add(new Party() { OrganiserName = "Ishwar", Date = "10 OCT 2020", IsAlcoholic = "Yes", Location = "Bathinda", Sex = "Any", ImageUrl = "https://media.gettyimages.com/photos/woman-lifts-her-arms-in-victory-mount-everest-national-park-picture-id507910624?s=612x612" });
        }

        // Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class Party
    {
        public string ImageUrl { get; set; }
        public string OrganiserName { get; set; }
        public string Date { get; set; }
        public string IsAlcoholic { get; set; }
        public string Location { get; set; }
        public string Sex { get; set; }

    }
}