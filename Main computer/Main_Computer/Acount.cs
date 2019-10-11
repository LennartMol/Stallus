using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Computer
{
    public class Acount
    {
        private string userName;

        public string UserName { get => userName; set => userName = value; }
        public Acount(string userName)
        {
            UserName = userName;
        }
    }
}
