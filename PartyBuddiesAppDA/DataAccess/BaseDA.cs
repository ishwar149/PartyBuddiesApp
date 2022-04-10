using Newtonsoft.Json;
using PartyBuddiesAppDA.BusinessObjects;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PartyBuddiesAppDA.DataAccess
{
    public class BaseDA
    {
        public static string BaseUrl = "http://192.168.1.106:45455/";//   //"http://seekparties.com/";  //
        private static RestClient client;
        private static RestRequest restRequest;
        private static string Token = string.Empty;
        private static string _email { get; set; }
        public static string Email
        {
            get
            {
                if (string.IsNullOrEmpty(_email))
                    _email = Convert.ToString(Application.Current.Properties["email"]);
                return _email;
            }
        }


        public static void SetHttpClient(string Url)
        {
            client = new RestClient(BaseUrl + Url);
        }

        public static IRestResponse CreateExecuteRequest<T>(string Url, T item, RestSharp.Method method)
        {
            SetHttpClient(Url);
            CreateRequest(item, method);
            IRestResponse response = client.Execute(restRequest);
            return response;
        }

        public static void CreateRequest<T>(T item, RestSharp.Method method)
        {
            restRequest = new RestRequest(method);
            if (Application.Current.Properties.ContainsKey("token"))
            {
                restRequest.AddParameter("token", Convert.ToString(Application.Current.Properties["token"]));
            }
            restRequest.AddParameter("application/x-www-form-urlencoded", "");
            foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
            {
                restRequest.AddParameter(propertyInfo.Name, propertyInfo.GetValue(item));
            }
        }


        public static T DeserializeRestResponse<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }



        #region  Upload Image
        public static IRestResponse ImageUploadRequest(string Url, UserImage item, Method method)
        {
            SetHttpClient(Url);
            restRequest = new RestRequest(method);
            restRequest.AddParameter("Email", item.Email);
            restRequest.Files.Add(FileParameter.Create("Image", item.Imagebyte, item.ImageName));
            restRequest.AddHeader("Content-Type", "multipart/form-data");
            IRestResponse response = client.Execute(restRequest);
            return response;
        }



        #endregion

    }
}
