using Acr.UserDialogs;
using PartyBuddiesApp.Validations;
using PartyBuddiesAppDA.BusinessObjects;
using PartyBuddiesAppDA.DataAccess;
using Plugin.FirebasePushNotification;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PartyBuddiesApp.ViewModels.LoginAndRegister
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : LoginViewModel
    {
        #region Fields
        private string password;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginPageViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.FacebookLogInCommand = new Command(this.FacebookLogIn);
        }

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
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
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command FacebookLogInCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void LoginClicked(object obj)
        {

            try
            {
                UserDialogs.Instance.ShowLoading("logging in please Wait...");
                await Task.Delay(200);
                Email = "ishwar3972@gmail.com";
                Password = "Password@123";
                //Check Validations
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || !IsValidEmail(Email))
                {
                    UserDialogs.Instance.Alert("Please Check Values", "Email or Password is empty or not valid", "Ok");
                    UserDialogs.Instance.HideLoading();
                }
                else
                {

                    App.MessageStatus = 1;
                    //Generate Toekn
                    IRestResponse response = PartyBuddiesAppDA.DataAccess.UserProfileDA.GetToken(new PartyBuddiesAppDA.BusinessObjects.LoginModel() { UserName = Email, password = Password, grant_type = "password" });
                    if (response.IsSuccessful)
                    {
                        App.MessageStatus = 2;
                        UserToken userToken = GetToken(response);
                        Application.Current.Properties["token"] = userToken.access_token;
                        Application.Current.Properties["email"] = Email;
                        //Update Firebase token if needed
                        UpdateFireBaseToken();
                        //Check if Otp Verified 
                        IRestResponse otpResponse = UserProfileDA.IsotpVerified(new UserProfile() { Email = Email });
                        if (otpResponse.Content == "True")
                        {
                            App.MessageStatus = 3;
                            Application.Current.Properties["otpverified"] = "True";
                            SetTabbedHomePage();
                        }
                        else
                        {
                            App.Current.MainPage = new NavigationPage(new Views.LoginAndRegister.OtpPage(Email));
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Please Check Values", "Wrong Email or Password", "Ok");
                    }
                    UserDialogs.Instance.HideLoading();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert($"Not Working {ex.Message}, LoginClicked,{App.MessageStatus}");
            }

        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            App.Current.MainPage = new Views.LoginAndRegister.SignUpPage();
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void ForgotPasswordClicked(object obj)
        {
            var label = obj as Label;
            label.BackgroundColor = Color.FromHex("#70FFFFFF");
            await Task.Delay(100);
            label.BackgroundColor = Color.Transparent;
        }

        /// <summary>
        /// Invoked when social media login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void FacebookLogIn(object obj)
        {
            // Do something
        }


        #endregion





    }
}