using EvaluationBackend.DATA.DTOs;

namespace EvaluationBackend.DATA
{
    public class vehicleFilter:BaseFilter
    {
        public int? VehicleNumber { get; set; }
        public string? character {  get; set; }
        public string? VehicleGovernarete { get; set; }
        public string? Vehicletypes { get; set; }
   
    }
}
 
