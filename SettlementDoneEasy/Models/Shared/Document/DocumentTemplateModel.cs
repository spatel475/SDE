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
        public int Creator { get; set; }
        public string FlowName { get; set; }
        public string Data { get; set; }


        public DocumentTemplate MapToEntity()
        {
            return new DocumentTemplate()
            {
                ID = ID,
                Creator = Creator,
                Data = Convert.FromBase64String(Data),
                FlowName = FlowName,
                OrganizationID = OrganizationID,
            };
        }


        public static DocumentTemplateModel MapFromEntity(DocumentTemplate entity)
        {
            return new DocumentTemplateModel()
            {
                ID = entity.ID,
                Creator = entity.Creator,
                Data = Convert.ToBase64String(entity.Data),
                FlowName = FlowName,
                OrganizationID = OrganizationID,
            };
        }

    }

}
