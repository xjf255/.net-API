using Microsoft.AspNetCore.Mvc;

namespace C_.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Juan", "Pedro", "Maria", "Jose", "Ana", "Luis", "Laura", "Carlos", "Sofia", "Miguel"
    };

    private readonly ILogger<UserController> _logger;

    private static List<User> ListUser = new List<User>();

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;

        if (ListUser == null || !ListUser.Any())
        {
            ListUser = Enumerable.Range(1, 5).Select(index => new User
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet(Name = "GetUser")]
    public IEnumerable<User> Get()
    {
        return ListUser;
    }

    [HttpPost]
}
