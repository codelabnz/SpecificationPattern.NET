using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecificationPatternExample.Specifications;

namespace SpecificationPatternExample.Domain
{
    public class CampaignRulesValidator
    {
        public Campaign Campaign { get; set; }
        public int? Timezone { get; set; }
        public TimeSpan? Length { get; set; }
        public int[] Stations { get; set; }

        public bool IsValid(SchedulingInfo schedulingInfo)
        {
            return BuildSpecifications().All(x => x.IsSatisfiedBy(schedulingInfo));
        }

        private List<ISpecification<SchedulingInfo>> BuildSpecifications()
        {
            List<ISpecification<SchedulingInfo>> specs = new List<ISpecification<SchedulingInfo>>();
            if (Timezone.HasValue)
                specs.Add(new ExpressionSpecification<SchedulingInfo>(x => x.Timezone == Timezone.Value));
            if (Length.HasValue)
                specs.Add(new ExpressionSpecification<SchedulingInfo>(x => x.Length == Length.Value));
            if (Stations != null)
                specs.Add(new ExpressionSpecification<SchedulingInfo>(x => x.Stations.SequenceEqual(Stations)));
            return specs;
        }
    }
}
