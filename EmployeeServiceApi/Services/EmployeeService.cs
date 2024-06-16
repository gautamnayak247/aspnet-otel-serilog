using System.Diagnostics;

namespace EmployeeServiceApi;
public class EmployeeService: IEmployeeService{
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(ILogger<EmployeeService> logger) => _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    public List<Employee> GetEmployees()
    {
        var activitySource = EmployeeServiceApiActivity.ActivitySource;
        using var activity = activitySource.StartActivity(nameof(GetEmployees));
        _logger.LogInformation("Fetching employee details");
        List<Employee> employees = new(){
            new Employee{ FirstName="Rahul", LastName="Dravid", Department="Batsman"},
            new Employee {FirstName = "Sachin", LastName="Tendulkar", Department="Batsman"},
            new Employee {FirstName = "Zaheer", LastName="Khan", Department= "Bowling"}
        };
        activity.AddEvent(new ActivityEvent("RetrievedEmployees"));
        return employees;  
    }
}
