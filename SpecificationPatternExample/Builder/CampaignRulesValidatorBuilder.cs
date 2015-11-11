using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecificationPatternExample.Domain;

namespace SpecificationPatternExample.Builder
{
    public class CampaignRulesValidatorBuilder
    {
        private readonly List<Action<CampaignRulesValidator>> _builderActions;

        public CampaignRulesValidatorBuilder()
        {
            _builderActions = new List<Action<CampaignRulesValidator>>();
        }
        public static CampaignRulesValidatorBuilder New()
        {
            return new CampaignRulesValidatorBuilder();
        }

        public CampaignRulesValidatorBuilder WithCampaign(Campaign campaign)
        {
            _builderActions.Add(x => x.Campaign = campaign);
            return this;
        }

        public CampaignRulesValidatorBuilder WithTimeZone(int timezoneId)
        {
            _builderActions.Add(x => x.Timezone = timezoneId);
            return this;
        }

        public CampaignRulesValidatorBuilder WithLength(TimeSpan length)
        {
            _builderActions.Add(x => x.Length = length);
            return this;
        }

        public CampaignRulesValidatorBuilder WithStations(int[] stations)
        {
            _builderActions.Add(x => x.Stations = stations);
            return this;
        }

        public CampaignRulesValidator Build()
        {
            CampaignRulesValidator newRulesValidator = new CampaignRulesValidator();
            _builderActions.ForEach(a => a(newRulesValidator));
            return newRulesValidator;
        }
    }
}
