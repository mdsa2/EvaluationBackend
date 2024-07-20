using EvaluationBackend.DATA.DTOs.Citizen;
using EvaluationBackend.DATA.DTOs.TypeOfVehicle;
using EvaluationBackend.DATA.DTOs.Vehical;
using EvaluationBackend.DATA.DTOs.VehicleGovernareteDtos;




namespace EvaluationBackend.DATA.DTOs.Vehical
{
    public class VehicalDto
    {
        public int Id { get; set; }
        public TypeOfVehicleDto? typeOfVechile { get; set; }
        public int? NumberOfVechile { get; set; }
        public string? character { get; set; }
        public VehicleGovernareteDto? VehiclesCities { get; set; }
        public string? carPartNumber { get; set; }
        public CitizenDto? CitizenDto { get; set; }
 
    }
}
