namespace Casestudy.Models
{
    public class Intern : Employee
    {
        public decimal Stipend { get; set; } = 500;

      
        public decimal CalculateSalary()
        {
            return BaseSalary + Stipend;
        }
    }
}
