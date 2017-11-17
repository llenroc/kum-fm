using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Mao.Application.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}