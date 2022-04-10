using System;
using System.Collections.Generic;
using System.Text;

namespace PartyBuddiesAppDA.BusinessObjects
{
    public class UserImage
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Email { get; set; }
        public byte[] Imagebyte { get; set; }

    }
}
