using PartyBuddiesAppDA.BusinessObjects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartyBuddiesAppDA.DataAccess
{
    public class UserProfileDA : BaseDA
    {
        public static IRestResponse Register(UserProfile profile)
        {
            return CreateExecuteRequest("api/Account/Register", profile, Method.POST);
        }

        public static IRestResponse IsotpVerified(UserProfile profile)
        {
            return CreateExecuteRequest("UserProfile/IsOtpVerified", profile, Method.POST);
        }

        public static IRestResponse GetToken(LoginModel model)
        {
            return CreateExecuteRequest("Token", model, Method.POST);
        }

        public static UserProfile GetUserProfile()
        {
            IRestResponse response = CreateExecuteRequest("UserProfile/GetUserProfile", new UserProfile() { Email = Email }, Method.GET);
            return DeserializeRestResponse<UserProfile>(response);
        }

        public static void UpdateFireBaseToken(string Email, string Firebasetoken)
        {
            CreateExecuteRequest("UserProfile/UpdateFireBaseToken", new UserProfile() { Email = Email, FireBaseToken = Firebasetoken }, Method.POST);
        }


    }
}
