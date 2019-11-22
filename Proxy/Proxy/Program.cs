using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Executing the method with a real subject:");
            RealSubject realSubject = new RealSubject();
            realSubject.RequestPassword();

            Console.WriteLine($"\nExecuting the method with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            proxy.RequestPassword();
        }
    }
}
