using Xamarin.Forms;
using Xamarin.Forms.Internals;
using PartyBuddiesAppDA.DataAccess;
using PartyBuddiesAppDA.BusinessObjects;
using System;
using System.Net.Http;
using RestSharp;
using Acr.UserDialogs;
using System.Threading.Tasks;
using PartyBuddiesApp.Validations;

namespace PartyBuddiesApp.ViewModels.LoginAndRegister
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : LoginViewModel
    {
        #region Fields

        private string name;

        private string password;

        private string confirmPassword;

        private string mobileNumber;

        private DateTime dateofbirth;

        private string _sex;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public SignUpPageViewModel()
        {
            DateOfBirth = System.DateTime.Now.ToShortDateString();
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.SexChangeCommand = new Command(this.SexCahngeClicked);
            //AddValidationRules();
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.NotifyPropertyChanged();
            }
        }

        //public ValidatableObject<string> Name { get; set; } = new ValidatableObject<string>();

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password from users in the Sign Up page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password confirmation from users in the Sign Up page.
        /// </summary>
        public string ConfirmPassword
        {
            get
            {
                return this.confirmPassword;
            }

            set
            {
                if (this.confirmPassword == value)
                {
                    return;
                }

                this.confirmPassword = value;
                this.NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        public string MobileNumber
        {
            get
            {
                return this.mobileNumber;
            }

            set
            {
                if (this.mobileNumber == value)
                {
                    return;
                }

                this.mobileNumber = value;
                this.NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Date of Birth from user in the Sign Up page.
        /// </summary>
        public string DateOfBirth
        {
            get
            {
                return this.dateofbirth.ToShortDateString();
            }

            set
            {
                if (this.dateofbirth.ToShortDateString() == value)
                {
                    return;
                }

                this.dateofbirth = Convert.ToDateTime(value);
                this.NotifyPropertyChanged();
            }
        }



        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Female Sex from user in the Sign Up page.
        /// </summary>
        public string Sex
        {
            get
            {
                return this._sex;
            }

            set
            {
                if (this._sex == value)
                {
                    return;
                }

                this._sex = value;
                this.NotifyPropertyChanged();
            }
        }



        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }


        /// <summary>
        /// Gets or sets the command that is executed when the Female Radio button is clicked.
        /// </summary>
        public Command SexChangeCommand { get; set; }


        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            App.Current.MainPage = new Views.LoginAndRegister.LoginPage();
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void SignUpClicked(object obj)
        {
            UserDialogs.Instance.ShowLoading("Creating Account Please Wait...");
            await Task.Delay(200);
            // Register User and send Token
            UserProfile profile = new UserProfile() { ConfirmPassword = ConfirmPassword, Email = Email, MobileNumber = MobileNumber, Password = Password, Name = Name, DateOfBirth = DateOfBirth, Sex = Sex, FireBaseToken = Convert.ToString(Application.Current.Properties["Firebasetoken"]) };
            IRestResponse HttpResponseMessage = UserProfileDA.Register(profile);
            if (HttpResponseMessage.IsSuccessful)
            {
                IRestResponse response = PartyBuddiesAppDA.DataAccess.UserProfileDA.GetToken(new PartyBuddiesAppDA.BusinessObjects.LoginModel() { UserName = Email, password = Password, grant_type = "password" });
                if (response.IsSuccessful)
                {
                    //Update Firebase token if needed
                    UpdateFireBaseToken();
                    UserToken userToken = GetToken(response);
                    Application.Current.Properties["token"] = userToken.access_token;
                    Application.Current.Properties["email"] = Email;
                    App.Current.MainPage = new NavigationPage(new Views.LoginAndRegister.OtpPage(profile.Email));
                }

            }
            UserDialogs.Instance.HideLoading();
        }

        private void SexCahngeClicked(object obj)
        {
            var sfradionbutton = obj as Syncfusion.XForms.Buttons.SfRadioButton;
            if (sfradionbutton.IsChecked == true)
                Sex = sfradionbutton.Text;
        }


        //public void AddValidationRules()
        //{
        //    Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name Required" });
        //    Name.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Email Required" });
        //}



        #endregion
    }
}