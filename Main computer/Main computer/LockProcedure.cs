using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_computer
{
    [Serializable]
    public class LockProcedure
    {
        public string StandID { get; set; }
        public string UserID { get; set; }
        public enum StartingWith { StandID, UserID }
        public StartingWith StartingType { get; private set; }
        public LockProcedure(string either, StartingWith type)
        {
            if (type == StartingWith.StandID)
            {
                StandID = either;
                UserID = "";
            }
            else
            {
                UserID = either;
                StandID = "";
            }
        }

        public override string ToString()
        {
            return $"{StandID}/{UserID}";
        }
    }
}
