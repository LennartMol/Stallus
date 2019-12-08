using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Main_computer
{
    public class LocalSafe
    {
        private readonly string path = "././LocalSafe/Instances.txt";
        public List<LockProcedure> Instances { get; private set; }
        public LocalSafe()
        {
            Instances = new List<LockProcedure>();
        }

        public void Save(List<LockProcedure> instances)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, instances);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public List<LockProcedure> Load()
        {
            FileStream fs = new FileStream($"{path}", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Instances = (List<LockProcedure>)formatter.Deserialize(fs);
                return Instances;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                return new List<LockProcedure>();
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
