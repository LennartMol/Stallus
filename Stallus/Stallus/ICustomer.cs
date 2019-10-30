using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallus
{
    interface ICustomer
    {
        string FirstName { get; }
        string LastName { get; }
        DateTime DateOfBirth { get;  }
        string Email { get;  }
        decimal Balance { get;  }
        string Password { get;  }
        Address Address { get;  }

       
    }
}
