using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayModelLibrary.Exception
{
    public class DomainException:System.Exception
    {
        public DomainException(string message):base(message)
        {

        }
    }
    public class DomainNotFoundException : DomainException
    {
        public DomainNotFoundException(string message) : base(message)
        {

        }
    }

    public class DomainValidationException : System.Exception
    {
        public DomainValidationException(string message) : base(message)
        {

        }
    }
}
