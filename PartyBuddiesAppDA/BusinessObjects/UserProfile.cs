using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace PartyBuddiesAppDA.BusinessObjects
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class UserProfile
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Sex { get; set; }

        public string DateOfBirth { get; set; }

        public bool IsOtpVerified { get; set; }

        public string Location { get; set; }

        public string UserID { get; set; }

        public string FireBaseToken { get; set; }

    }
}
