using EvaluationBackend.Interface;

namespace EvaluationBackend.Repository
{
    public interface IRepositoryWrapper
    {
   
        IUserRepository User { get; }
        IPermissionRepository Permission { get; }
        IArticleRespository Article { get; }
        ICitizenRepositry citizenRepositry { get; }
        IFineRepositry fineRepositry { get; }
        IReportRepositry reportRepositry { get; }
        IVehicalRepositry IVehicalRepositry { get; }
        ItypeOfVehicleRepositry itypeOfVehicleRepositry { get; }
        IReportPlates reportPlates { get; }
        ICharacterRepositry characterRepositry { get; }
        IPlaceFineRepositry placeFineRepositry { get; }
        IGovRepositry govRepositry { get; }
        IFineTypeRepositry fineTypeRepositry { get; }
        IVehicleCityRepositry VehicleCityRepositry { get; }
        
        IRoleRepository Role { get; }
        
    }
}