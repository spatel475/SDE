﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class DocumentTemplate
    {
        public DocumentTemplate()
        {
            Document = new HashSet<Document>();
        }

        public int ID { get; set; }
        public int? OrganizationID { get; set; }
        public int? Creator { get; set; }
        public byte[] Data { get; set; }
        public string FlowName { get; set; }

        public virtual Users CreatorNavigation { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Document> Document { get; set; }
    }
}
