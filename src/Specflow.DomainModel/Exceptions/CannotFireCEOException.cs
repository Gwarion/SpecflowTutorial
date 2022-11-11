using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.DomainModel.Exceptions
{
    public class CannotFireCEOException : Exception
    {
        public CannotFireCEOException() : base("Interdit de renvoyer le patron !") { }
    }
}
