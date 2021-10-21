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
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }

        public List<DocumentAuditModel> Audits { get; set; }
        public DocumentTemplateModel Template { get; set; }
        public DocumentDataModel DocumentData { get; set; }

        public Domain.Entities.Document MapToDocument()
        {
            return new Domain.Entities.Document() {
                ID = ID,
                UserID = UserID,
                Data = Data,
                TemplateID = TemplateID,
                CreationDate = CreationDate,
                Title = Title,
                DocumentAudit = Audits.Select(d => d.MapToEntity()).ToList(),
                Template = Template.MapToEntity(),
                DocumentData = DocumentData.MapToEntity(),
            };
        }

        public static DocumentModel MapFromDocument(Domain.Entities.Document document)
        {
            return new DocumentModel()
            {
                ID = document.ID,
                UserID = document.UserID,
                Data = document.Data,
                TemplateID = document.TemplateID,
                CreationDate = document.CreationDate,
                Title = document.Title,
                Audits = document.DocumentAudit.Select(d => DocumentAuditModel.MapFromEntity(d)).ToList(),
                DocumentData = DocumentDataModel.MapFromEntity(document.DocumentData),
                Template = DocumentTemplateModel.MapFromEntity(document.Template)
            };
        }
    }
}
