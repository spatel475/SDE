using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class DocumentDatum
    {
        public int Id { get; set; }
        public byte[] AdjustedData { get; set; }
        public byte[] ArchiveData { get; set; }

        public virtual Document IdNavigation { get; set; }
    }
}
