using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class DocumentUser
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public int? DocID { get; set; }

        public virtual Document Doc { get; set; }
        public virtual Users User { get; set; }
    }
}
