﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class Organization
    {
        public Organization()
        {
            DocumentTemplates = new HashSet<DocumentTemplate>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<DocumentTemplate> DocumentTemplates { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}