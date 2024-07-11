using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EvaluationBackend.Entities
{
    public class Citizen:BaseEntity<int>
    {
 
        public string? Name { get; set; }
        public int? Phonenumber { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Vehical> Vehicles { get; set; }
    }
}
