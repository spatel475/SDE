using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDE_Server.Models.Document
{
    public class DocumentModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Data { get; set; }
        public int TemplateID { get; set; } 
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }

        public List<DocumentAuditModel> Audits { get; set; }
        public DocumentTemplateModel Template { get; set; }
        public DocumentDataModel DocumentData { get; set; }

        public Domain.Entities.Document MapToEntity()
        {
            return new Domain.Entities.Document() {
                ID = ID,
                UserID = UserID,
                Data = Data,
                TemplateID = TemplateID,
                CreationDate = CreationDate,
                Title = Title,
                DocumentAudit = Audits?.Select(d => d.MapToEntity()).ToList(),
                Template = Template?.MapToEntity(),
                DocumentData = DocumentData?.MapToEntity(),
            };
        }

        public static DocumentModel MapFromEntity(Domain.Entities.Document entity)
        {
            if (entity == null)
                return null;

            return new DocumentModel()
            {
                ID = entity.ID,
                UserID = entity.UserID,
                Data = entity.Data,
                TemplateID = entity.TemplateID,
                CreationDate = entity.CreationDate,
                Title = entity.Title,
                Audits = entity.DocumentAudit.Select(d => DocumentAuditModel.MapFromEntity(d)).ToList(),
                DocumentData = (entity.DocumentData != null) ? DocumentDataModel.MapFromEntity(entity.DocumentData) : null,
                Template = DocumentTemplateModel.MapFromEntity(entity.Template)
            };
        }
    }
}
