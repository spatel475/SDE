using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDE_Server.Domain.ReleaseStatemachine
{
    public class ReleaseStateInfo
    {
        public int StateId { get; set; }
        public List<ReleaseStateTrigger> AvailableTriggers { get; set; }

    }
}
