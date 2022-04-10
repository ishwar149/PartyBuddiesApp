using PartyBuddiesAppDA.BusinessObjects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Plugin.Media.Abstractions;
using System.IO;
using System.Collections.ObjectModel;

namespace PartyBuddiesAppDA.DataAccess
{
    public class UserImageDA : BaseDA
    {
        public static ObservableCollection<UserImage> GetImages()
        {
            IRestResponse response = CreateExecuteRequest("UserImage/GetImages", new UserProfile() { Email = Email }, Method.GET);
            ObservableCollection<UserImage> userimages = DeserializeRestResponse<ObservableCollection<UserImage>>(response);
            for (int i = 0; i < userimages.Count; i++)
            {
                userimages[i].ImageUrl = $"{BaseUrl}{userimages[i].ImageUrl}";
            }
            return userimages;
        }


        public static void UploadImages(MediaFile uimage)
        {
            byte[] imagearray;
            using (var memoryStream = new MemoryStream())
            {
                uimage.GetStream().CopyTo(memoryStream);
                imagearray = memoryStream.ToArray();
            }
            UserImage userImage = new UserImage()
            {
                Email = Email,
                Imagebyte = imagearray,
                ImageName = System.IO.Path.GetFileName(uimage.Path)
            };
            ImageUploadRequest("UserImage/UploadImage", userImage, Method.POST);
        }
    }
}
