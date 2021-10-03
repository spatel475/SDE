using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class Organization
    {
        public Organization()
        {
            DocumentTemplate = new HashSet<DocumentTemplate>();
            Users = new HashSet<User>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<DocumentTemplate> DocumentTemplate { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
