namespace Casestudy.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public decimal BaseSalary { get; set; }
    }
}
