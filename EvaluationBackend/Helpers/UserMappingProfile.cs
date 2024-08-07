using AutoMapper;
using EvaluationBackend.DATA.DTOs;
using EvaluationBackend.DATA.DTOs.ArticleDto;
using EvaluationBackend.DATA.DTOs.Citizen;
using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA.DTOs.FineType;
using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.DATA.DTOs.PlaceName;
using EvaluationBackend.DATA.DTOs.Reports;
using EvaluationBackend.DATA.DTOs.roles;
using EvaluationBackend.DATA.DTOs.TypeOfVehicle;
using EvaluationBackend.DATA.DTOs.User;
using EvaluationBackend.DATA.DTOs.Vehical;
using EvaluationBackend.DATA.DTOs.VehicleGovernareteDtos;

using EvaluationBackend.Entities;
using OneSignalApi.Model;


namespace EvaluationBackend.Helpers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {

            CreateMap<AppUser, UserDto>()
            .ForMember(r => r.Role , src => src.MapFrom(src => src.Role.Name));
            CreateMap<RegisterForm,App>().ForAllMembers( opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Role, RoleDto>();
            CreateMap<AppUser, AppUser>();
            //Citizen
            CreateMap<Citizen, CitizenDto>();
            CreateMap<CitizenForm, Citizen>();
            CreateMap<UpdateCitizen, Citizen>();
            //Fine
            CreateMap<Fine, FineDto>();
            CreateMap<FineForm, Fine>();
            CreateMap<FineUpdateDto, Fine>();
            //Fine Type
            CreateMap<FineTypes,FineTypeDto>();
            CreateMap<FineTypeForm,Fine>();
            CreateMap<FineTypeUpdate,Fine>();
            //Govarnrate
            CreateMap<Gov,GovsDto>();
            CreateMap<GovForm,Gov>();
            CreateMap<GovForm,Gov>();
            //typeofVehicle
            CreateMap<TypeOfVehicles, TypeOfVehicleDto>();
            CreateMap<TypeOFVehicleForm, TypeOfVehicles>();
            CreateMap<TYpeOFVehicleUpdate, TypeOfVehicles>();
            //place Name
            CreateMap<PlaceFine, PlaceNameDto>();
            CreateMap<PlaceNameForm, PlaceFine>();
            CreateMap<PlaceNameUpdate, PlaceFine>();

            //Vehicle
            CreateMap<Vehical, VehicalDto>()

                 .ForMember(dest => dest.CitizenDto, opt => opt.MapFrom(src => src.Citizen))
                 .ForMember(dest => dest.VehiclesCities, opt => opt.MapFrom(src => src.vehiclesGovernarete))


            ;

            

            CreateMap<VehicalForm, Vehical>()
            .ForMember(dest => dest.Citizen, opt => opt.MapFrom(src => src.CitizenForm))
           
            ;
            CreateMap<VehicalUpdate, Vehical>();
          
            //Vehicle City
            CreateMap<VehiclesGovernarete, VehicleGovernareteDto>()
                 .ForMember(dest => dest.vehiclegovernarete, opt => opt.MapFrom(src => src.VehicleGovernarte))
            

                ;
            CreateMap<VehicleGovernareteForm, VehiclesGovernarete>()
               

                ;
            CreateMap<VehicleGovernareteUpdate, VehiclesGovernarete>();
            CreateMap<Fine, FinePlates>();



            CreateMap<Fine, FineUserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.AppUser.FullName))
                ;
       
            


          
         
    
         


            CreateMap<Permission, PermissionDto>();

        }
    }
}