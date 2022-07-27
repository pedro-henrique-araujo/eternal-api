using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    public class ContractTemplateCreationDto
    {
        [Required, StringLength(150, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required, MinLength(3)]
        public string? Text { get; set; }
    }
}
