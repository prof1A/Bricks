using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks.Exceptions
{
    class NumberException : Exception
    {
        public NumberException(string message) : base(message)
        {

        }
    }
}
