using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.DATA.DTOs.TypeOfVehicle;
using EvaluationBackend.DATA.DTOs.Vehical;
using EvaluationBackend.Entities;
using System.ComponentModel.DataAnnotations;

namespace EvaluationBackend.DATA.DTOs.Citizen
{
    public class CitizenForm
    {
        public string? Name { get; set; }
        public int? PhoneNumber { get; set; }
    
    }
}
