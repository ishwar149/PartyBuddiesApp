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
    public class UserToken
    {
        public string access_token { get; set; }
        public string email { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string userName { get; set; }
                
    }


}
