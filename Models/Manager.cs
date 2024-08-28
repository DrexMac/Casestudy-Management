namespace CaseStudy.Models
{
    public class Manager : Employee
    {
        public Manager(string name) : base(name, 5000m, "Manager")
        {
        }

        public override decimal CalculateSalary()
        {
            return BaseSalary;
        }
    }
}
