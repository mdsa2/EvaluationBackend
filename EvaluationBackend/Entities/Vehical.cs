namespace EvaluationBackend.Entities
{
    public class Vehical:BaseEntity<int>
    {
       
      
        public int? NumberOfVechile { get; set; }
     
        public string? GovOfVehicle { get; set; }
        public string? carPartNumber { get; set; }
        public int? CitizenId { get; set; }
        public int TypeOfVechileId { get; set; }
        public TypeOfVehicles? typeOfVechile { get; set; }
        public Citizen? Citizen { get; set; }
        public ICollection<Fine>? Fines { get; set; }
     
    }
}
