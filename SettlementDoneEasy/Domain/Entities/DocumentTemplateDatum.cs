using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class DocumentTemplateDatum
    {
        public int? TemplateId { get; set; }
        public byte[] Template { get; set; }
    }
}
