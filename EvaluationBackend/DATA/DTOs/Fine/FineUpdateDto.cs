﻿namespace EvaluationBackend.DATA.DTOs.Fine
{
    public class FineUpdateDto
    {
        public int? GovId { get; set; }
        public int? DesNumber { get; set; }
        public int? Number { get; set; }

        public int? FineTypeId { get; set; }

  
        public string? Location { get; set; }
        public string? character { get; set; }
        public int? VechileId { get; set; }
    }
}
