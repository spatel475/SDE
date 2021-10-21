using SDE_Server.Domain.Entities;
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
        public int CreatorID { get; set; }
        public string FlowName { get; set; }
        public string Data { get; set; }
        public DocumentTemplateDataModel TemplateData { get; set; }

        public DocumentTemplate MapToEntity()
        {
            return new DocumentTemplate()
            {
                ID = ID,
                CreatorID = CreatorID,
                Data = Convert.FromBase64String(Data),
                FlowName = FlowName,
                OrganizationID = OrganizationID,
            };
        }


        public static DocumentTemplateModel MapFromEntity(DocumentTemplate entity)
        {
            if (entity == null)
                return null;

            return new DocumentTemplateModel()
            {
                ID = entity.ID,
                CreatorID = entity.CreatorID,
                Data = (entity.Data != null) ? Convert.ToBase64String(entity.Data) : null,
                FlowName = entity.FlowName,
                OrganizationID = entity.OrganizationID,
                TemplateData = (entity.DocumentTemplateData.FirstOrDefault() != null) ? DocumentTemplateDataModel.MapFromEntity(entity.DocumentTemplateData.FirstOrDefault()) : null
            };
        }

    }

}
