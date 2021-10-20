using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDE_Server.Models.Document
{
    public class DocumentModel
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public string Data { get; set; }
        public int? TemplateID { get; set; } // idk if this will be needed so i'll leave it in for now


        public DocumentAuditModel Audits { get; set; }
        public DocumentTemplateDataModel Template { get; set; }
        public DocumentDataModel DocumentData { get; set; }

        public SDE_Server.Domain.Entities.Document MapToDocument()
        {
            var document = new Domain.Entities.Document();

            document.ID = ID;
            document.UserID = UserID;
            document.Data = Data;
            document.TemplateID = TemplateID;

            return document;
        }
    }
}
