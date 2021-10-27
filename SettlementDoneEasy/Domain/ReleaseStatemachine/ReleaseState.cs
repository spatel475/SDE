using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDE_Server.Domain.ReleaseStatemachine
{
    public enum ReleaseState
    {
        P1_Draft = 1,
        P1_Edit = 2,
        P2_Received= 3,
        P2_Accepted=4,
        P3_Recieved=5,
        P1_Rejected=6,
        P1_Complete=7,
        P1_Trash=8,
        P1_Archive=9,
    }


}
