using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class DocumentAudit
    {
        public int ID { get; set; }
        public int? DocID { get; set; }
        public string Description { get; set; }
        public string FlowState { get; set; }

        public virtual Document Doc { get; set; }
    }
}
