using EvaluationBackend.DATA.DTOs.FineType;
using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.DATA.DTOs.Vehical;
using EvaluationBackend.Entities;

namespace EvaluationBackend.DATA.DTOs.Fine
{
    public class FineDto
    {
        
  
        public GovsDto? gov {  get; set; }
        public int? DesNumber { get; set; }
        public FineTypeDto? fineType { get; set; }
        public VehicalDto? vehical { get; set; }
        public DateTime? CreationTime {  get; set; }
        public string? Location { get; set; }
        public string? character { get; set; }

        public FineStatus? Status { get; set; }
 

    }
}
