using EvaluationBackend.DATA.DTOs;
using EvaluationBackend.Entities;

namespace EvaluationBackend.DATA
{
    public class FineFilter : BaseFilter
    {

        public int? numbervehicle { get; set; }
        public string? Vehicletype { get; set; }
        public string? character { get; set; }
        public string? VehicleGovernarete {get;set;}
        public int? VehicleId  { get; set; }

      
    
    }
}
