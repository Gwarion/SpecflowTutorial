namespace Specflow.DomainModel
{
    public class Company
    {
        public string Name { get; set; } = string.Empty;
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Company() { }

        public double GetTotalSalary()
        {
            return Employees.Sum(e => e.Salary);
        }

        public void IncreaseSalary()
        {
            Employees.ForEach(e =>
            {
                _ = e.Rank switch
                {
                    Rank.CEO => e.Salary += 50000,
                    Rank.Manager => e.Salary += 10000,
                    Rank.Regular => e.Salary += 1000,
                    _ => throw new NotImplementedException()
                };
            });
        }
    }
}