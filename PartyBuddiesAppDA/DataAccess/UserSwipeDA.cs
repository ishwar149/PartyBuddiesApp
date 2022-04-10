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
    public class UserSwipeDA : BaseDA
    {
        public static IRestResponse Add(UserSwipe UserSwipe)
        {
            UserSwipe.UserEmail = Email;
            return BaseDA.CreateExecuteRequest("UserSwipe/Add", UserSwipe, Method.POST);
        }

    }
}
