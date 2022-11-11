using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.DomainModel.Exceptions
{
    public class EmployeeAlreadyFiredException : Exception
    {
        public EmployeeAlreadyFiredException() : base("Cet employee ne travaille plus pour nous !") { }
    }
}
