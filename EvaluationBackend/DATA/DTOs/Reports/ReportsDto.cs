using EvaluationBackend.DATA.DTOs.Vehical;
using EvaluationBackend.Entities;

namespace EvaluationBackend.DATA.DTOs.Reports
{
    public class ReportsDto
    {
        public int Id { get; set; }
        public int number {  get; set; }
  
        public FineStatus? fineStatus { get; set; }
        public PlaceFine? placeFine { get; set; }
        public DateTime? CreationDate { get; set; }
        public VehicalDto? vehicalDto { get; set; }
       
        public string? FullName { get; set; }
    }
}
