﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Main_computer
{
    public class Verification
    {
        private RNGCryptoServiceProvider RNGCryptoService;
        private byte[] Bytes;
        public Verification()
        {
            RNGCryptoService = new RNGCryptoServiceProvider();
            Bytes = new byte[2];
        }

        public string GetNewKey()
        {
            RNGCryptoService.GetBytes(Bytes);
            UInt16 key = 0;
            key |= Bytes[0];
            _ = Bytes[1] << 8;
            return "";
        }
    }
}
