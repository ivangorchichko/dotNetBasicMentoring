using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.CustomExceptions
{
    public class DuplicateTaskException : Exception
    {
        public DuplicateTaskException()
        {
        }

        public DuplicateTaskException(string message)
            : base(message)
        {
        }
    }
}
