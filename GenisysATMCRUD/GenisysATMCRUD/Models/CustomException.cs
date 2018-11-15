using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenisysATM.Models
{
    class CustomException : Exception
    {
        // Constructores
        public CustomException() : base() { }

        public CustomException(string message) : base(message) { }

        public CustomException(string format, params object[] args)
            : base(string.Format(format, args)) { }
    }
}
