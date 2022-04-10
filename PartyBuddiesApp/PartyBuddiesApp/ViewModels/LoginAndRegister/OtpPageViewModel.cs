using Acr.UserDialogs;
using PartyBuddiesAppDA.BusinessObjects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PartyBuddiesApp.ViewModels.LoginAndRegister
{
    /// <summary>
    /// ViewModel for Otp page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class OtpPageViewModel : BaseViewModel
    {

        #region Fields

        private string otp;
        private string email;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the email ID from user in the login page.
        /// </summary>
        public string OTP
        {
            get
            {
                return this.otp;
            }

            set
            {
                if (this.otp == value)
                {
                    return;
                }

                this.otp = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the email ID from user in the login page.
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.email == value)
                {
                    return;
                }

                this.email = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public OtpPageViewModel()
        {
            Email = $"{Application.Current.Properties["email"]}";
            this.VerifyOtpCommand = new Command(this.VerifyOtpClicked);
            this.LoginCommand = new Command(this.LoginClicked);
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command VerifyOtpCommand { get; set; }


        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void VerifyOtpClicked(object obj)
        {
            UserDialogs.Instance.ShowLoading("Verifying OTP");
            await Task.Delay(200);
            IRestResponse response = PartyBuddiesAppDA.DataAccess.OtpDA.Verify(new Otp() { GeneratedOtp = OTP, Email = email });
            if (response.Content == "True")
            {
                Application.Current.Properties["otpverified"] = "True";
                SetTabbedHomePage();
            }
            else
            {
                UserDialogs.Instance.Alert("Please Enter Corrent OTP", "Wrong OTP", "Ok");
            }
            UserDialogs.Instance.HideLoading();
        }

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            App.Current.MainPage = new Views.LoginAndRegister.LoginPage();
        }

        #endregion
    }
}
