using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MiniThingsIDo
{
    interface IHashing
    {
        string HashingString(string strNotHashed);
    }
    class Hashing : IHashing
    {
        /// <summary>
        /// method that hashes the string
        /// </summary>
        /// <param name="strNotHashed"></param>
        /// <returns>Hased string</returns>
        public string HashingString(string strNotHashed)
        {
            byte[] b = Encoding.UTF8.GetBytes(strNotHashed);//מעביר את המחרוזת למערך של ביטיים
            SHA256Managed hashStringSha = new SHA256Managed();
            byte[] hash = hashStringSha.ComputeHash(b);//עושה ההשש למערך ביטיים
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += string.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
