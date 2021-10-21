using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDE_Server.Domain.Entities;

namespace SDE_Server.Models.Document
{
    public class DocumentDataModel
    {
        public int ID { get; set; }
        public string AdjustedData { get; set; }
        public string ArchiveData { get; set; }


        public DocumentData MapToEntity()
        {
            return new DocumentData()
            {
                AdjustedData = Convert.FromBase64String(AdjustedData),
                ArchiveData = Convert.FromBase64String(ArchiveData),
                ID = ID,
            };
        }

        public static DocumentDataModel MapFromEntity(DocumentData entity)
        {
            return new DocumentDataModel()
            {
                AdjustedData = Convert.ToBase64String(entity.AdjustedData),
                ArchiveData = Convert.ToBase64String(entity.ArchiveData),
                ID = entity.ID
            };
        }
    }

   
}
