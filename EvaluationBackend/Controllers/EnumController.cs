using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EvaluationBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EnumController : BaseController
    {
        [HttpGet("Enum")]
        public IActionResult GetEnums()
        {
            var enums = Assembly.GetAssembly(typeof(EnumController))
                .GetTypes()
                .Where(t=>t.IsEnum)
                .Select(type=>new
                {
                    type.Name,
                    Values = Enum.GetValues(type)
                    .Cast<Enum>()
                    .Select(Value => new {Name=Value.ToString(), Value=Value})
                })
                .ToList();
            return Ok(new { Enums = enums });
        }

    }
}
