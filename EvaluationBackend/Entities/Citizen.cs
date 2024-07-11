namespace EvaluationBackend.Entities
{
    public class Citizen:BaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Phonenumber { get; set; }
        public ICollection<Vehical> Vehicles { get; set; }
    }
}
