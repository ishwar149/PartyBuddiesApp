using System;
using System.Collections.Generic;
using System.Text;

namespace PartyBuddiesAppDA.BusinessObjects
{
    public class Otp
    {
        public int ID { get; set; }
        public string GeneratedOtp { get; set; }
        public System.DateTime GeneratedOn { get; set; }
        public string Email { get; set; }
        public decimal MobileNumber { get; set; }
    }
}
