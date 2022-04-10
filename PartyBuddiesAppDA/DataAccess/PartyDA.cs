using PartyBuddiesAppDA.BusinessObjects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartyBuddiesAppDA.DataAccess
{
    public class PartyDA : BaseDA
    {
        public static IRestResponse Add(Party Party)
        {
            Party.Email = Email;
            return BaseDA.CreateExecuteRequest("Party/Add", Party, Method.POST);
        }

        public static ObservableCollection<SwipeHomeModel> GetParties()
        {
            ObservableCollection<SwipeHomeModel> Parties = DeserializeRestResponse<ObservableCollection<SwipeHomeModel>>(BaseDA.CreateExecuteRequest("Party/GetParties", new UserProfile() { Email = Email }, Method.POST));
            for (int i = 0; i < Parties.Count; i++)
            {
                Parties[i].ImageUrl = $"{BaseUrl}{Parties[i].ImageUrl}";
                //DateTime DateOfBirth = DateTime.ParseExact(Parties[i].DateOfBirth.Split(' ')[0], "MM/dd/yyyy", null);
                Parties[i].Age = Convert.ToString(System.DateTime.Now.Year - Parties[i].DateOfBirth.Year);
            }
            return Parties;

        }

        public static List<Party> GetUserParties()
        {
            return DeserializeRestResponse<List<Party>>(BaseDA.CreateExecuteRequest("Party/GetUserParties", new UserProfile() { Email = Email }, Method.POST));

        }


    }
}
