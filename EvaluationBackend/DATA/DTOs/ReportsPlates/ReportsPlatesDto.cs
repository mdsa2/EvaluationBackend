using EvaluationBackend.DATA.DTOs.Vehical;
using EvaluationBackend.Entities;

namespace EvaluationBackend.DATA.DTOs.ReportsPlates
{
    public class ReportsPlatesDto
    {
        public int number { get; set; }
      
        public FineStatus fineStatus { get; set; }
        public PlaceFine placeFine { get; set; }
        public DateTime? CreationDate { get; set; }
        public VehicalDto? vehicalDto { get; set; }
    }
}
