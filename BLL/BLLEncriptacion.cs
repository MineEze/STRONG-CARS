using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using System.Security.Cryptography;

namespace BLL
{
    public class BLLEncriptacion
    {
        public string Encriptar(string valor)
        {
            string hash;
            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;

            sSourceData = valor;
            tmpSource = Encoding.ASCII.GetBytes(sSourceData);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            hash = ByteArrayToString(tmpHash);

            return hash;
        }

        private string ByteArrayToString(byte[] arrInput)
        {
            int i = 0;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i <= arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
