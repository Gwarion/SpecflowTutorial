using Specflow.DomainModel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.DomainModel
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Rank Rank { get; set; }
        public int Salary { get; set; }
        public Status Status { get; set; }

        public Employee() => Status = Status.Hired;


        public string GetFullName()
        {
            if (string.IsNullOrWhiteSpace(FirstName)) { throw new ArgumentNullException($"{nameof(FirstName)} not set"); }
            if (string.IsNullOrWhiteSpace(LastName)) { throw new ArgumentNullException($"{nameof(LastName)} not set"); }

            return $"{FirstName} {LastName}";
        }

        public void RaiseSalary()
        {
            _ = Rank switch
            {
                Rank.CEO => Salary += 50000,
                Rank.Manager => Salary += 10000,
                Rank.Regular => Salary += 1000,
                _ => throw new NotImplementedException()
            };
        }

        public void Fire()
        {
            if (Rank == Rank.CEO)
            {
                throw new CannotFireCEOException();
            }

            if (Status == Status.Fired)
            {
                throw new EmployeeAlreadyFiredException();
            }

            Status = Status.Fired;
        }
    }

    public enum Status
    {
        Hired,
        Fired
    }

    public enum Rank
    {
        CEO,
        Manager,
        Regular
    }
}
