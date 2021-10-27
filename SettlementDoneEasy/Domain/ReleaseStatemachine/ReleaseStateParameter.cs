using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDE_Server.Domain.ReleaseStatemachine
{
    public class ReleaseStateParameter
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }
        public bool Required { get; set; }
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
