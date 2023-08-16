using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Helpers.Exceptions
{
    public class RightsException : Exception
    {
        public RightsException(string message) : base(message) { }
    }
}
