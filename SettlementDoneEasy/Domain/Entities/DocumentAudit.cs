using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class DocumentAudit
    {
        public int Id { get; set; }
        public int? DocId { get; set; }
        public string Description { get; set; }
        public string FlowState { get; set; }

        public virtual Document Doc { get; set; }
    }
}
