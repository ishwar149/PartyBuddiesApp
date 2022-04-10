using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PartyBuddiesAppDA.BusinessObjects
{
    public class Party
    {
        public int ID { get; set; }
        public string PartyAlcoholic { get; set; }
        public string PartyVegetarian { get; set; }
        public string PartyAddress { get; set; }
        public string PartyPlace { get; set; }
        public string BuddyGenderPreference { get; set; }
        public int BuddyMinAgePreference { get; set; }
        public int BuddyMaxAgePreference { get; set; }
        public System.DateTime PartyDate { get; set; }
        public string PartyTime { get; set; }
        public string IsPartyExpenseShared { get; set; }
        public string IsNightAccomodation { get; set; }
        public Guid UserID { get; set; }
        public string Email { get; set; }
        public decimal PartyLongitude { get; set; }
        public decimal PartyLatitude { get; set; }
        public string PartyDateString { get; set; }

        public Command EditPartyCommand { get; set; }

    }
}
