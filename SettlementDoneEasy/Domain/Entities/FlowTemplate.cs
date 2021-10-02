using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class FlowTemplate
    {
        public FlowTemplate()
        {
            DocumentTemplates = new HashSet<DocumentTemplate>();
        }

        public int ID { get; set; }
        public string Machine { get; set; }

        public virtual ICollection<DocumentTemplate> DocumentTemplates { get; set; }
    }
}
