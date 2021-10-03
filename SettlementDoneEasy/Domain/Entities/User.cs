using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Document = new HashSet<Document>();
            DocumentTemplate = new HashSet<DocumentTemplate>();
            DocumentUser = new HashSet<DocumentUser>();
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? OrganizationID { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<DocumentTemplate> DocumentTemplate { get; set; }
        public virtual ICollection<DocumentUser> DocumentUser { get; set; }
    }
}
