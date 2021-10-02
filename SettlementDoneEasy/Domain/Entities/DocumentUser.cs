using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class DocumentUser
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? DocId { get; set; }

        public virtual Document Doc { get; set; }
        public virtual User User { get; set; }
    }
}
