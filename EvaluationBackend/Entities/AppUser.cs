using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EvaluationBackend.Entities
{
    public class AppUser : BaseEntity<Guid>
    {
        public string? Email { get; set; }
        
        public string? FullName { get; set; }
        
        public string? Password { get; set; }
        public string? UserImage { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
    
    }
    
}