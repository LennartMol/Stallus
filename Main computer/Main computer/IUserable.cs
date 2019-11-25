using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_computer
{
    interface IUserable
    {
        string FirstName { get; }
        string LastName { get; }
        DateTime DateOfBirth { get; }
        string Email { get; }
        string Password { get; }
        Address Address { get; }
        decimal Balance { get; }
    }
}
