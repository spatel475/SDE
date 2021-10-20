using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDE_Server.Models.Document
{
    public class DocumentTemplateModel
    {
        public int ID { get; set; }
        public int OrganizationID { get; set; }
        public int Creator { get; set; }
        public int FlowTemplate { get; set; }
        public string Data { get; set; }
    }
}
