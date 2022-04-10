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
    public class LoginModel
    {
        private string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }


        public string UserName
        {
            get
            {
                return this.username;
            }

            set
            {
                if (this.username == value)
                {
                    return;
                }

                this.username = value;
            }
        }
    }
}
