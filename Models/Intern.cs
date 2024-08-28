namespace CaseStudy.Models
{
    public class Intern : Employee
    {
        public Intern(string name) : base(name, 2000m, "Intern")
        {
            
        }

        public override decimal CalculateSalary()
        {
            return base.CalculateSalary();
        }
    }
}
