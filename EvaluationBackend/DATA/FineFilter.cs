using EvaluationBackend.DATA.DTOs;
using EvaluationBackend.Entities;

namespace EvaluationBackend.DATA
{
    public class FineFilter:BaseFilter
    {
        public int? number { get; set; }
        public int? numbervehicle { get; set; }
        public string? Name { get; set; }
        public int? VehicleId  { get; set; }

 
        public FineStatus? Status { get; set; }
    }
}
