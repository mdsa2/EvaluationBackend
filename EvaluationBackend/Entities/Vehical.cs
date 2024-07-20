using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EvaluationBackend.Entities
{
    public class Vehical:BaseEntity<int>
    {
       
      
        public int? NumberOfVechile { get; set; }
     
     
        public string? carPartNumber { get; set; }
        public int CitizenId { get; set; }
        
        public Citizen? Citizen { get; set; }

        public int characterId { get; set; }
        public Character? character { get; set; }
        public int VehicleGovernareteId { get; set; }
        public VehiclesGovernarete? vehiclesGovernarete { get; set; }
        public int TypeOfVechileId { get; set; }
 
        public TypeOfVehicles? typeOfVechile { get; set; }
     
        public ICollection<Fine>? Fines { get; set; }
     
    }
}
