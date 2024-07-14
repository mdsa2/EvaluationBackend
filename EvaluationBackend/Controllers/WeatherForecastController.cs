
using EvaluationBackend.DATA;
using EvaluationBackend.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationBackend.Controllers;

[ServiceFilter(typeof(AuthorizeActionFilter))]

public class WeatherForecastController : BaseController
{
    private readonly DataContext _context;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public WeatherForecastController(DataContext context) 
    {
        _context = context;
    }
}