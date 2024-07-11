using EvaluationBackend.DATA.DTOs.FineType;
using EvaluationBackend.DATA.DTOs.GovDto;

namespace EvaluationBackend.DATA.DTOs.Fine;

public class FineUserDto
{
    public GovsDto? gov {  get; set; }
    public int? DesNumber { get; set; }
    public FineTypeDto? fineType { get; set; }
 
    public int? Number { get; set; }
    public string? Location { get; set; }
    public string? Status { get; set; }
    public  string? username { get; set; }

}