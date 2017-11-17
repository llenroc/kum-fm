using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Mao.Application.Editions.Dto;

namespace Mao.Application.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}