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
        public DateTime CreationDate { get; set; }

        public Domain.Entities.DocumentAudit MapToEntity()
        {
            return new Domain.Entities.DocumentAudit()
            {
                CreationDate = this.CreationDate,
                Description = this.Description,
                DocID = this.DocID,
                FlowState = this.FlowState,
                ID = this.ID,
                State = this.State
            };
        }

        public static DocumentAuditModel MapFromEntity(Domain.Entities.DocumentAudit entity)
        {
            return new DocumentAuditModel()
            {
                CreationDate = entity.CreationDate,
                Description = entity.Description,
                DocID = entity.DocID,
                FlowState = entity.FlowState,
                ID = entity.ID,
                State = entity.State
            };
        }
    }
}
