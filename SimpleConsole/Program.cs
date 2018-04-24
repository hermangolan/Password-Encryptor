using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = "123456";
            string user = "boby";
            string encryptedPass = "";
            string randomString = "";
            string[] s = MiniThingsIDo.PassAlgorithmWord.BuildTheFirstEncryptPass(pass);
            encryptedPass = s[0];
            randomString = s[1];
            MiniThingsIDo.ActOfDatabase database = new MiniThingsIDo.ActOfDatabase();
            database.AddUser(user, encryptedPass, randomString);
            string[] savedS = database.getUser(user);
            string savedEncryptedPass = savedS[0];
            string savedRandomString = savedS[1];
            if ((savedEncryptedPass.Equals(encryptedPass)) && (savedRandomString.Equals(randomString)))
            {
                Console.WriteLine("Works");
                Console.WriteLine(savedEncryptedPass);
                MiniThingsIDo.Logger.Log(savedEncryptedPass);
            }
            else
                Console.WriteLine("Doesnt Work");
            Console.ReadLine();
        }
    }
}
