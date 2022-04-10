using PartyBuddiesAppDA.BusinessObjects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartyBuddiesAppDA.DataAccess
{
    public class OtpDA : BaseDA
    {
        public static IRestResponse Verify(Otp otp)
        {
            return BaseDA.CreateExecuteRequest("Otp/VerifyOtp", otp, RestSharp.Method.POST);
        }
    }
}
