using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class Document
    {
        public Document()
        {
            DocumentAudit = new HashSet<DocumentAudit>();
            DocumentUser = new HashSet<DocumentUser>();
        }

        public int ID { get; set; }
        public int UserID { get; set; }
        public string Data { get; set; }
        public int TemplateID { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual DocumentTemplate Template { get; set; }
        public virtual Users User { get; set; }
        public virtual DocumentData DocumentData { get; set; }
        public virtual ICollection<DocumentAudit> DocumentAudit { get; set; }
        public virtual ICollection<DocumentUser> DocumentUser { get; set; }
    }
}
