using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PartyBuddiesApp.Views.LoginAndRegister
{
    /// <summary>
    /// Page to sign in with user details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleSignUpPage" /> class.
        /// </summary>
        public SignUpPage()
        {
            InitializeComponent();
        }

        void DatePicker_Clicked(object sender, System.EventArgs e)
        {
            this.datepicker.IsOpen = true;
        }
    }
}