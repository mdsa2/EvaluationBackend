namespace EvaluationBackend.Entities
{
    public class Fine : BaseEntity<int>
    {


        public int? GovId { get; set; }
        public Gov? Gov { get; set; }
        public int? DesNumber { get; set; }
        public int? Number { get; set; }

        public int? FineTypeId { get; set; }
        public FineTypes? FineType { get; set; }


        public int? PlaceFineId { get; set; }
        public PlaceFine? placeFine { get; set; }


        public FineStatus? Status { get; set; } = FineStatus.Pending;


        public decimal? Price { get; set; }
        public int? VechileId { get; set; }
        public Vehical? Vehicle { get; set; }
        public AppUser? AppUser { get; set; }
        public string? Location { get; set; }
       
        public string? garageName { get;set;}

        public DateTime? CreationDate { get; set; } = DateTime.UtcNow;
    }

    public enum FineStatus
    {
        Pending=0,
        Paid=1,
        Unpaid=2,
    }
}
