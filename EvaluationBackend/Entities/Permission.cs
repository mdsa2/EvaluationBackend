namespace EvaluationBackend.Entities
{
    public class Permission : BaseEntity<int>
    {
        public string? Subject { get; set; } 
        public string? Action { get; set; }
        public string? FullName { get; set; }
        
        
        public List<RolePermission> RolePermissions { get; set; }
        
    }
    
   
}