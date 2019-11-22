using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public class RealSubject : ISubject 
    {
        public void RequestPassword()
        {
            Console.WriteLine("Requesting password.");
        }
    }
}
