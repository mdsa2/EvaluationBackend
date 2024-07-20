
using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.Interface;
using EvaluationBackend.Respository;
using EvaluationBackend.Services;

namespace EvaluationBackend.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        private IUserRepository _user;  
        private IArticleRespository _articles;
        private IPermissionRepository _permission;
        private IReportRepositry _report;
        private IFineRepositry _fine;
        private ItypeOfVehicleRepositry _typevehicle;
        private IVehicalRepositry _vehicle;
        private IGovRepositry _gov;
        private IFineTypeRepositry _typefine;
        private IPlaceFineRepositry _placefine;
        private IReportPlates _reportplates;
        private ICharacterRepositry _character;
        private ICitizenRepositry _citizen;
        private IVehicleCityRepositry _City;
        private IRoleRepository _role;
        
        public IRoleRepository Role {  get {
            if(_role == null)
            {
                _role = new RoleRepository(_context,_mapper);
            }
            return _role;
        } }
        
        public IPermissionRepository Permission {  get {
            if(_permission == null)
            {
                _permission = new PermissionRepository(_context,_mapper);
            }
            return _permission;
        } }

        public IReportPlates reportPlates
        {
            get
            {
                if (_reportplates == null)
                {
                    _reportplates = new ReportsPlatesRepositry(_context, _mapper);
                }
                return _reportplates;
            }
        }
        public ICharacterRepositry characterRepositry
        {
            get
            {
                if (_character == null)
                {
                    _character = new characterRepositry(_context, _mapper);
                }
                return _character;
            }
        }
        public IArticleRespository Article {  get {
            if(_articles == null)
            {
                _articles = new ArticleRepositry(_context,_mapper);
            }
            return _articles;
        } }
        public IVehicleCityRepositry VehicleCityRepositry
        {
            get
            {
                if (_City == null)
                {
                    _City = new VehicleCityRepositry(_context, _mapper);
                }
                return _City;
            }
        }


        public IUserRepository User {  get {
            if(_user == null)
            {
                _user = new UserRepository(_context,_mapper);
            }
            return _user;
        } }

        public ICitizenRepositry citizenRepositry
        {
            
                get {
                    if (_citizen == null)
                    {
                        _citizen = new CitizenRepositry(_context, _mapper);
                    }
                    return _citizen;
                
            }
        }

        public IFineRepositry fineRepositry
        {

            get
            {
                if (_fine == null)
                {
                    _fine = new FineRepositry(_context, _mapper);
                }
                return _fine;

            }

        }

        public IReportRepositry reportRepositry
        {

            get
            {
                if (_report == null)
                {
                    _report = new ReportRepositry(_context, _mapper);
                }
                return _report;

            }
        }

        public IVehicalRepositry IVehicalRepositry
        {
            get
            {
                if (_vehicle == null)
                {
                    _vehicle = new VehicleRepositry(_context, _mapper);
                }
                return _vehicle;

            }

        }

        public ItypeOfVehicleRepositry itypeOfVehicleRepositry
        {
            get
            {
                if (_typevehicle == null)
                {
                    _typevehicle = new typeOfVehicleRepositry(_context, _mapper);
                }
                return _typevehicle;

            }

        }
        public IFineTypeRepositry fineTypeRepositry
        {
            get
            {
                if (_typefine == null)
                {
                    _typefine = new FineTypeRepositry(_context, _mapper);
                }
                return _typefine;

            }

        }

        public IPlaceFineRepositry placeFineRepositry
        {
            get
            {
                if (_placefine == null)
                {
                    _placefine = new PlaceFineRepositry(_context, _mapper);
                }
                return _placefine;

            }

        }

        public IGovRepositry govRepositry
        {
            get
            {
                if (_gov == null)
                {
                    _gov = new GovRepositry(_context, _mapper);
                }
                return _gov;

            }

        }

 

        public RepositoryWrapper(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
    }
}