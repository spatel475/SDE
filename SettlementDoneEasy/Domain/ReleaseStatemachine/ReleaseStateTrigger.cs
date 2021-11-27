
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDE_Server.Domain.ReleaseStatemachine
{
    public class ReleaseStateTrigger
    {
        public ReleaseStateTrigger(int triggerId, string label, string desc)
        {
            this.TriggerId = triggerId;
            this.Label = label;
            this.Description = desc;
        }

        public int TriggerId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        
    }
}
