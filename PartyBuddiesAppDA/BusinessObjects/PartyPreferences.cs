using System;
using System.Collections.Generic;
using System.Text;

namespace PartyBuddiesAppDA.BusinessObjects
{
    public class PartyPreferences
    {
        public int ID { get; set; }
        public string PartyTypeAlcoholic { get; set; }
        public Nullable<int> PartyDistance { get; set; }
        public string PartyBuddyPreference { get; set; }
        public Nullable<int> PartyBuddyMinAge { get; set; }
        public Nullable<int> PartyBuddyMaxAge { get; set; }
        public string PartyTime { get; set; }
        public string PartyExpense { get; set; }
        public string NightAccomodation { get; set; }
        public string Email { get; set; }
        public Nullable<int> UserID { get; set; }

        public string PartyPlace { get; set; }

    }
}
