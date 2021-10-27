using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDE_Server.Domain.Entities;

namespace SDE_Server.Models.Document
{
    public class DocumentTemplateDataModel
    {
        public int TemplateID { get; set; }
        public string Template { get; set; }


        public DocumentTemplateData MapToEntity()
        {
            return new DocumentTemplateData()
            {
                Template = Convert.FromBase64String(Template),
                TemplateID = TemplateID
            };
        }


        public static DocumentTemplateDataModel MapFromEntity(DocumentTemplateData entity)
        {
            if (entity == null)
                return null;

            return new DocumentTemplateDataModel()
            {
                Template = Convert.ToBase64String(entity.Template),
                TemplateID = entity.TemplateID
            }; 
        }
    }

}
