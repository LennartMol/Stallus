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
        public string Key { get; private set; }
        public bool IsLocked { get; set; }
        public DateTime DateTime { get; private set; }
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
            IsLocked = false;
            DateTime = DateTime.Now;
        }

        public LockProcedure(string stand_id, string userid, string key)
        {
            StandID = stand_id;
            UserID = userid;
            Key = key;
            IsLocked = false;
            DateTime = DateTime.Now;
        }

        public LockProcedure(string stand_id, string userid)
        {
            StandID = stand_id;
            UserID = userid;
            Key = null;
            IsLocked = false;
            DateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{StandID}/{UserID}/{Key}/{IsLocked}/{DateTime.ToString("hh:mm:ss DD-MM-YYYY")}";
        }
    }
}
