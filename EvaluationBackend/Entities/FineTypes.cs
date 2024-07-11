namespace EvaluationBackend.Entities
{
    public class FineTypes:BaseEntity<int>
    {
      
        public string? Name { get; set; }
        public decimal? Price { get; set; }
    }
}
