using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDBApp.Models
{
    public partial class Contact
    {
        public long Id { get; set; }
        public string ContactType { get; set; }
        public string ContactData { get; set; }
        public long PersonId { get; set; }
        public bool InUse { get; set; }

        public virtual Person Person { get; set; }
    }
}
