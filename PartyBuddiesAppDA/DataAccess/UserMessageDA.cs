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
    public class UserMessageDA : BaseDA
    {
        public static IRestResponse Add(UserMessage userMessage)
        {
            return BaseDA.CreateExecuteRequest("UserMessage/Add", userMessage, Method.POST);
        }

    }
}
