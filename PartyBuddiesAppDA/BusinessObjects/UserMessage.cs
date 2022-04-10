using System;
using System.Collections.Generic;
using System.Text;

namespace PartyBuddiesAppDA.BusinessObjects
{
    public class UserMessage
    {
        public int ID { get; set; }
        public string MessageTo { get; set; }
        public string MessageFrom { get; set; }
        public Nullable<System.DateTime> MessageDate { get; set; }
        public Nullable<bool> IsRead { get; set; }

        public string MessageText { get; set; }

    }
}
