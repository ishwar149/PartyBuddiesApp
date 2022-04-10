using System;
using System.Collections.Generic;
using System.Text;

namespace PartyBuddiesAppDA.BusinessObjects
{
    public partial class UserSwipe
    {
        public int ID { get; set; }
        public int PartyID { get; set; }
        public string OrganiserEmail { get; set; }
        public string UserEmail { get; set; }
        public string UserAction { get; set; }
        public string OrganiserAction { get; set; }
        public bool IsSwipeNotificationSent { get; set; }
        public bool IsSwipeNotificationRead { get; set; }
        public Nullable<bool> IsAcceptedNotificationSent { get; set; }
        public Nullable<bool> IsAcceptedNotificationRead { get; set; }

        public string FireBaseToken { get; set; }
    }
}
