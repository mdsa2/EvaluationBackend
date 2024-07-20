using EvaluationBackend.DATA.DTOs.FineType;
using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.Entities;

namespace EvaluationBackend.DATA.DTOs.Fine
{
    public class FinePlates
    {
        public GovsDto? gov { get; set; }
        public int? DesNumber { get; set; }
        public FineTypeDto? fineType { get; set; }

        public int? Number { get; set; }

        public FineStatus? Status { get; set; }
 
        public string? garageName { get; set; }
    }
}
