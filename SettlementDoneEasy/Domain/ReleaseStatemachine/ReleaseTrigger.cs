using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDE_Server.Domain.ReleaseStatemachine
{
    public enum ReleaseTrigger
    {
        Edit = 0,
        Save = 1,
        Transmit = 2,
        Accept = 3,
        Reject = 4,
        Trash = 5,
        Archive= 6,
    }
}
