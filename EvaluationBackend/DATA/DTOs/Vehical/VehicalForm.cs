﻿using EvaluationBackend.DATA.DTOs.Citizen;

namespace EvaluationBackend.DATA.DTOs.Vehical
{
    public class VehicalForm
    {

        public int TypeOfVechileId { get; set; }
        public int? NumberOfVechile { get; set; }

        public string? CityOfVehicle { get; set; }
        public string? carPartNumber { get; set; }
        public CitizenForm? CitizenForm { get; set; }
         
    }
}