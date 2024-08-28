namespace Casestudy.Models
{
    public class Developer : Employee
    {
        public decimal OvertimeHours { get; set; }
        public decimal OvertimeRate { get; set; } = 20;

        
        public decimal CalculateSalary()
        {
            return BaseSalary + (OvertimeHours * OvertimeRate);
        }
    }
}
