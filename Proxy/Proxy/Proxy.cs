using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public class Proxy : ISubject
    {
        private RealSubject realSubject;    

        public Proxy(RealSubject realsubject)
        {
            realsubject = realSubject;
        }

        public void RequestPassword()
        {
            if (CheckAccess())
            {
                realSubject = new RealSubject();
                realSubject.RequestPassword();

                LogAccess();
            }

        }

        private bool CheckAccess()
        {
            Console.WriteLine($"Checking access before executing the RequestPassword method.");
            return true;
        }

        private void LogAccess()
        {
            DateTime now = new DateTime();
            Console.WriteLine($"Time of logging: {now}.");
        }
    }
}
