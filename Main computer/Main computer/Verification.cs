using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Main_computer
{
    public class Verification
    {
        private readonly RNGCryptoServiceProvider RNGCryptoService;
        private readonly byte[] Bytes;
        public Verification()
        {
            RNGCryptoService = new RNGCryptoServiceProvider();
            Bytes = new byte[2];
        }

        public string GetNewKey()
        {
            RNGCryptoService.GetBytes(Bytes);
            long key = Bytes[0] | Bytes[1] << 8;
            return key.ToString();
        }
    }
}
