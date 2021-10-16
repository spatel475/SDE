using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDE_Server.Models.Document
{
    public class DocumentDataModel
    {
        public int ID { get; set; }
        public byte[] AdjustedData { get; set; }
        public byte[] ArchiveData { get; set; }

    }
}
