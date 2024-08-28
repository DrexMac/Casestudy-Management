using Casestudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Casestudy.Pages
{
    public class PeopleModel : PageModel
    {
        private readonly MyDbcontext _context;

        public List<Employee> Employees { get; set; } = new List<Employee>();

        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public string SelectedRole { get; set; } = string.Empty;

        public PeopleModel(MyDbcontext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Employees = _context.Employees.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(SelectedRole))
            {
                ModelState.AddModelError(string.Empty, "Name and Role are required.");
                return Page();
            }

            decimal defaultBaseSalary = SelectedRole switch
            {
                "Manager" => 1000m,
                "Developer" => 800m,
                "Intern" => 500m,
                _ => 0m
            };

            Employee? newEmployee = SelectedRole switch
            {
                "Manager" => new Manager { Name = Name, Role = "Manager", BaseSalary = defaultBaseSalary },
                "Developer" => new Developer { Name = Name, Role = "Developer", BaseSalary = defaultBaseSalary },
                "Intern" => new Intern { Name = Name, Role = "Intern", BaseSalary = defaultBaseSalary },
                _ => null
            };

            if (newEmployee == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid role selected.");
                return Page();
            }

            decimal finalSalary = newEmployee switch
            {
                Manager manager => manager.CalculateSalary(),
                Developer developer => developer.CalculateSalary(),
                Intern intern => intern.CalculateSalary(),
                _ => defaultBaseSalary
            };


            newEmployee.BaseSalary = finalSalary;

            _context.Employees.Add(newEmployee);
            _context.SaveChanges();

            return RedirectToPage();
        }

    }
}
