using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    public class ContractTemplateUpdatingDto
    {
        [Required, Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required, MinLength(3)]
        public string? Text { get; set; }
    }
}
