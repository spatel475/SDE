using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class DocumentTemplate
    {
        public DocumentTemplate()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? Creator { get; set; }
        public int? FlowTemplate { get; set; }
        public byte[] Data { get; set; }

        public virtual User CreatorNavigation { get; set; }
        public virtual FlowTemplate FlowTemplateNavigation { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
