using System;
using SpecificationPatternExample.Builder;
using SpecificationPatternExample.Domain;
using Xunit;
using FluentAssertions;

namespace SpecificationPatternExample.UnitTests
{
   
    public class CampaignRulesValidatorSuite
    {
        private Campaign _campaign = new Campaign()
        {
            Id = 1234
        };
        private readonly int _timezone = 2;
        
        [Fact]
        public void setting_campaign_timezone_length_stations_with_valid_schedulinginfo_is_satisified()
        {
            CampaignRulesValidatorBuilder builder = CampaignRulesValidatorBuilder.New();
            SchedulingInfoBuilder schedulingBuilder = SchedulingInfoBuilder.New();
            TimeSpan length = TimeSpan.FromMinutes(30);
            int[] stations = new int[] { 223, 224 };

            CampaignRulesValidator validator = builder.WithCampaign(_campaign).WithLength(length).WithStations(stations).WithTimeZone(_timezone).Build();
            SchedulingInfo schedulingInfo = schedulingBuilder.WithLength(length).WithStations(stations).WithTimeZone(_timezone).Build();

            var result = validator.IsValid(schedulingInfo);
            result.Should().BeTrue("the rules state the length, stations and timezone should match");

        }

        [Fact]
        public void setting_campaign_timezone_only_with_valid_schedulinginfo_is_satisified()
        {
            CampaignRulesValidatorBuilder builder = CampaignRulesValidatorBuilder.New();
            SchedulingInfoBuilder schedulingBuilder = SchedulingInfoBuilder.New();
          
            CampaignRulesValidator validator = builder.WithCampaign(_campaign).WithTimeZone(_timezone).Build();
            SchedulingInfo schedulingInfo = schedulingBuilder.WithTimeZone(_timezone).Build();

            var result = validator.IsValid(schedulingInfo);
            result.Should().BeTrue("the rules state the timezone should match");

        }

        [Fact]
        public void setting_campaign_timezone_length_stations_with_different_schedulinginfo_is_not_satisified()
        {
            CampaignRulesValidatorBuilder builder = CampaignRulesValidatorBuilder.New();
            SchedulingInfoBuilder schedulingBuilder = SchedulingInfoBuilder.New();
            TimeSpan length = TimeSpan.FromMinutes(30);
            int[] stations = new int[] { 223, 224 };
            int otherTimezone = 999;

            CampaignRulesValidator validator = builder.WithCampaign(_campaign).WithLength(length).WithStations(stations).WithTimeZone(_timezone).Build();
            SchedulingInfo schedulingInfo = schedulingBuilder.WithLength(length).WithTimeZone(otherTimezone).Build();

            var result = validator.IsValid(schedulingInfo);
            result.Should().BeFalse("the rules state the length, stations and timezone should match but the scheduling info is missing stations and different timezone");
        }

    }
}
