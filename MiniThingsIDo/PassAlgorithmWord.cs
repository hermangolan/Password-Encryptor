using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniThingsIDo
{
    public static class PassAlgorithmWord
    {
        /// <summary>
        /// Generates a random string
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomString(Random rand, int lengthOfpass)
        {
            string randStr = "";
            for (int i = 0; i < lengthOfpass; i++)
            {
                char temp;
                do
                {
                    temp = Convert.ToChar(rand.Next(65, 123));
                } while (!IsGoodChar(temp));
                randStr += temp;
            }

            return randStr;
        }
        public static bool IsGoodChar(char c)
        {
            switch (c)
            {
                case '/':
                    return false;
                case '\\':
                    return false;
                case '@':
                    return false;
                default:
                    return true;
            }
        }
        /// <summary>
        /// Takes the string argument and sparates it to 'mini' strings,
        /// if there is a moudule when string length divided by the timesSapareted there will be one more mini string
        /// </summary>
        /// <param name="str">The string argument</param>
        /// <param name="timesSpareted">how many 'mini' strings you want (less than the length of the string)</param>
        /// <returns></returns>
        public static List<string> SparateString(string str, int timesSpareted)
        {
            if (str.Length < timesSpareted)
                throw new Exception("the timeSparated is bigger than the length of the string");

            int lengthOfEachString = str.Length / timesSpareted;
            bool remeberToAddTheLastDigits = false;
            if (str.Length % timesSpareted != 0)
            {
                remeberToAddTheLastDigits = true;
            }
            List<string> miniStrings = new List<string>();
            int dividingStrEnd = lengthOfEachString;
            int dividingStrStart = 0;
            if (remeberToAddTheLastDigits)
            {
                while (dividingStrEnd > str.Length)
                {
                    miniStrings.Add(str.Substring(dividingStrStart, dividingStrEnd));
                    dividingStrStart += lengthOfEachString;
                    if (dividingStrEnd > str.Length - lengthOfEachString)
                        dividingStrEnd += lengthOfEachString;
                    else
                        dividingStrEnd += str.Length - lengthOfEachString;

                }
            }
            else
            {
                while (dividingStrEnd > str.Length)
                {
                    miniStrings.Add(str.Substring(dividingStrStart, dividingStrEnd));
                    dividingStrStart += lengthOfEachString;
                    dividingStrEnd += lengthOfEachString;
                }
            }
            return miniStrings;
        }
        /// <summary>
        /// method to encrypt new password
        /// </summary>
        /// <param name="pass">password</param>
        /// <returns></returns>
        public static string[] BuildTheFirstEncryptPass(string pass)
        {
            string randomStr = GenerateRandomString(new Random(),pass.Length);
            return BuildTheEncryptPass(pass, randomStr);
        }
        /// <summary>
        /// method to encrypt a password
        /// </summary>
        /// <param name="pass">password</param>
        /// <param name="randomString">the 'salt'</param>
        /// <returns></returns>
        public static string[] BuildTheEncryptPass(string pass, string randomString)
        {
            List<string> mini_pass = SparateString(pass, 2);
            string encryptedpass = string.Empty;
            foreach (string x in mini_pass)
            {
                encryptedpass += x + randomString;
            }
            Hashing h = new Hashing();
            string[] l = new string[2];
            l[0] = h.HashingString(encryptedpass);
            l[1] = randomString;
            return l;
        }

    }
}
