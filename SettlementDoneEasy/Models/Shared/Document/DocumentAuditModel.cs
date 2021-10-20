using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDE_Server.Models.Document
{
    public class DocumentAuditModel
    {
        public int ID { get; set; }
        public int DocID { get; set; }
        public string Description { get; set; }
        public string FlowState { get; set; }
        public int State { get; set; }
    }
}
