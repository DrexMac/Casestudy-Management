namespace CaseStudy.Models
{
    public class Employee
    {
        public string? Name { get; set; }
        public Decimal BaseSalary { get; set; }
        public string? Role { get; set; }

        public Employee(string? name, decimal baseSalary, string? role)
        {
            Name = name;
            BaseSalary = baseSalary;
            Role = role;
        }

        public virtual decimal CalculateSalary() 
        {
            return BaseSalary;
        }
    }

}
