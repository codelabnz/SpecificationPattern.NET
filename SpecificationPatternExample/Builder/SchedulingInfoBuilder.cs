using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecificationPatternExample.Domain;

namespace SpecificationPatternExample.Builder
{
    public class SchedulingInfoBuilder
    {
        private readonly List<Action<SchedulingInfo>> _builderActions;

        public SchedulingInfoBuilder()
        {
            _builderActions = new List<Action<SchedulingInfo>>();
        }
        public static SchedulingInfoBuilder New()
        {
            return new SchedulingInfoBuilder();
        }

        public SchedulingInfoBuilder WithTimeZone(int timezoneId)
        {
            _builderActions.Add(x => x.Timezone = timezoneId);
            return this;
        }

        public SchedulingInfoBuilder WithLength(TimeSpan length)
        {
            _builderActions.Add(x => x.Length = length);
            return this;
        }

        public SchedulingInfoBuilder WithStations(int[] stations)
        {
            _builderActions.Add(x => x.Stations = stations);
            return this;
        }

        public SchedulingInfo Build()
        {
            SchedulingInfo newSchedulingInfo = new SchedulingInfo();
            _builderActions.ForEach(a => a(newSchedulingInfo));
            return newSchedulingInfo;
        }
    }
}
