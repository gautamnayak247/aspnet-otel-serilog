using Microsoft.AspNetCore.Mvc;

namespace EmployeeServiceApi.Controllers;

[ApiController]
[Route("api/v1/employees")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeService _employeeService;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    } 

    [HttpGet(Name = "GetEmployees")]
    public IActionResult GetEmployees()
    {
        var activitySource = EmployeeServiceApiActivity.ActivitySource;
        using var activity = activitySource.StartActivity(nameof(GetEmployees));
        _logger.LogInformation("Getting list of employees");
        var employees = _employeeService.GetEmployees();
        return Ok(employees);
    }
}
