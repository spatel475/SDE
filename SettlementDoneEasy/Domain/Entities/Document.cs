using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class Document
    {
        public Document()
        {
            DocumentAudits = new HashSet<DocumentAudit>();
            DocumentUsers = new HashSet<DocumentUser>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Data { get; set; }
        public int? TemplateId { get; set; }

        public virtual DocumentTemplate Template { get; set; }
        public virtual User User { get; set; }
        public virtual DocumentDatum DocumentDatum { get; set; }
        public virtual ICollection<DocumentAudit> DocumentAudits { get; set; }
        public virtual ICollection<DocumentUser> DocumentUsers { get; set; }
    }
}
