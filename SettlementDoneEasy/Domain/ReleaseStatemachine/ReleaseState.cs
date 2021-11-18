using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDE_Server.Domain.ReleaseStatemachine
{
    public enum ReleaseState
    {
        P1_Draft = 0,
        P1_Edit = 1,
        P2_Received= 2,
        P2_Accepted=3,
        P3_Recieved=4,
        P1_Rejected=5,
        P1_Complete=6,
        P1_Trash=7,
        P1_Archive=8,
    }


}
