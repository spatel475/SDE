﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class DocumentTemplateData
    {
        public int? TemplateID { get; set; }
        public byte[] Template { get; set; }
    }
}