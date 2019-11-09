using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_computer
{
    public class DatabaseNotReachableException : Exception
    {
        public string ExceptionMessage { get; private set; }
        public DatabaseNotReachableException()
        {
            ExceptionMessage = Message;
        }
    }
}
