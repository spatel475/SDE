using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDE_Server.Domain.ReleaseStatemachine
{
    public class ReleaseContext
    {
        public string MachineName { get; set; }
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public Dictionary<int,ReleaseStateTrigger> Triggers { get; set; }
      
    }
}
