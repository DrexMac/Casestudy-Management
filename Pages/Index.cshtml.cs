using CaseStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CaseStudy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private const string ManagementSystem = "Employees";

        public List<Employee> Employees
        {
            get
            {
                var management = HttpContext.Session.GetString(ManagementSystem);
                return management != null ? JsonConvert.DeserializeObject<List<Employee>>(management) ?? new List<Employee>() : new List<Employee>();
            }

            set
            {
                HttpContext.Session.SetString(ManagementSystem, JsonConvert.SerializeObject(value));
            }
        }

        [BindProperty]
        public string? EmployeeName { get; set; }

        [BindProperty]
        public string? EmployeeRole { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var employees = Employees;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Employee? newEmployee = null;

            if (EmployeeRole == "Manager")
            {
                newEmployee = new Manager(EmployeeName ?? string.Empty);
            }

            else if (EmployeeRole == "Developer")
            {
                newEmployee = new Developer(EmployeeName ?? string.Empty);
            }

            else if (EmployeeRole == "Intern")
            {
                newEmployee = new Intern(EmployeeName ?? string.Empty);
            }

            if (newEmployee != null)
            {
                var employees = Employees;
                employees.Add(newEmployee);
                Employees = employees;
            }

            return RedirectToPage("/Index");
        }
    }
}
