using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            DocumentTemplates = new HashSet<DocumentTemplate>();
            DocumentUsers = new HashSet<DocumentUser>();
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<DocumentTemplate> DocumentTemplates { get; set; }
        public virtual ICollection<DocumentUser> DocumentUsers { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
