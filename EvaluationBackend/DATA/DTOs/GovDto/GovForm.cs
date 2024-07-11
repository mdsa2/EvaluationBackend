using System.ComponentModel.DataAnnotations;

namespace EvaluationBackend.DATA.DTOs.GovDto

{
    public class GovForm
    {
        [Required]
        public string Name { get; set; }
    }
}
