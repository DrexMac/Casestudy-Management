namespace Casestudy.Models
{
    public class Manager : Employee
    {
        public decimal Bonus { get; set; } = 1000;

        
        public decimal CalculateSalary()
        {
            return BaseSalary + Bonus;
        }
    }
}
