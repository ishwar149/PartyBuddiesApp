using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PartyBuddiesApp.Views.Templates
{
    /// <summary>
    /// Class helps to reduce repetitive markup, and allows an apps appearance to be more easily changed.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomStyle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomStyle" /> class.
        /// </summary>
        public CustomStyle()
        {
            InitializeComponent();
        }
    }
}