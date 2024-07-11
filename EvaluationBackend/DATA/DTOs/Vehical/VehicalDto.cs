using EvaluationBackend.DATA.DTOs.Citizen;
using EvaluationBackend.DATA.DTOs.TypeOfVehicle;
using EvaluationBackend.Entities;

namespace EvaluationBackend.DATA.DTOs.Vehical
{
    public class VehicalDto
    {
        public TypeOfVehicleDto? typeOfVechile { get; set; }
        public int NumberOfVechile { get; set; }

        public string? CityOfVehicle { get; set; }
        public string? carPartNumber { get; set; }
        public CitizenDto? CitizenDto { get; set; }
 
    }
}
