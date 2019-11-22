using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Main_computer
{
    public class DbCheck
    {
        public bool Reachable { get; private set; }
        public MySqlException SqlException { get; private set; }
        public DbCheck(bool reachable, MySqlException exception)
        {
            Reachable = reachable;
            SqlException = exception;
        }
        public DbCheck(bool reachable)
        {
            Reachable = reachable;
        }
    }
}