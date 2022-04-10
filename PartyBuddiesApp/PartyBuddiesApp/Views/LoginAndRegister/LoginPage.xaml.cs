using Acr.UserDialogs;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PartyBuddiesApp.Views.LoginAndRegister
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLoginPage" /> class.
        /// </summary>
        public LoginPage()
        {
            BindingContext = App.ViewModelLocator.LoginPageVM;
            InitializeComponent();
        }
    }
}