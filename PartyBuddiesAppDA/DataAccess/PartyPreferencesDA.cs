using PartyBuddiesAppDA.BusinessObjects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyBuddiesAppDA.DataAccess
{
    public class PartyPreferencesDA : BaseDA
    {
        public static IRestResponse Add(PartyPreferences Party)
        {
            Party.Email = Email;
            return BaseDA.CreateExecuteRequest("PartyPreferences/Add", Party, Method.POST);
        }


        public static PartyPreferences GetUserPreferences()
        {
            IRestResponse restResponse = BaseDA.CreateExecuteRequest("PartyPreferences/GetUserPreferences", new UserProfile() { Email = Email }, Method.POST);
            if (restResponse != null)
                return DeserializeRestResponse<PartyPreferences>(restResponse);
            else return null;

        }


    }
}
