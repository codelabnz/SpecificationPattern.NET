using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPatternExample.Domain
{
    public class BookingLine
    {
        public string Id { get; set; }
        public Guid ContractId { get; set; }
    }
}
