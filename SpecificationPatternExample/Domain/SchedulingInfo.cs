using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPatternExample.Domain
{
    public class SchedulingInfo
    {
        public string Id { get; set; }
        public int Timezone { get; set; }
        public int LineType { get; set; }
        public Guid ContractId { get; set; }
        public TimeSpan Length { get; set; }
        public int[] Stations { get; set; }
    }
}
