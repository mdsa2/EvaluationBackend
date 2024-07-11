using EvaluationBackend.DATA.DTOs.Citizen;

namespace EvaluationBackend.DATA.DTOs.Vehical
{
    public class VehicalUpdate
    {
        public int TypeOfVechileId { get; set; }
        public int NumberOfVechile { get; set; }

        public int VehicleCityId { get; set; }
        public string? carPartNumber { get; set; }
        public CitizenForm? CitizenForm { get; set; }
    }
}
