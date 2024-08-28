namespace CaseStudy.Models
{
    public class Developer : Employee
    {
        public Developer(string name) : base(name, 4000m, "Developer")
        {
        }

        public override decimal CalculateSalary()
        {
            return BaseSalary;
        }
    }
}
