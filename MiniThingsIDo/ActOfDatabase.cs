using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniThingsIDo
{
    /// <summary>
    /// A class that acts like a database or more like a table in a database
    /// </summary>
    public class ActOfDatabase
    {
        private Dictionary<string, string> passwordAndUserStorage;
        private Dictionary<string, string> passwordAndSaltStorage;

        public ActOfDatabase()
        {
            passwordAndUserStorage = new Dictionary<string, string>();
            passwordAndSaltStorage = new Dictionary<string, string>();

        }
        /// <summary>
        /// Adds a user in the 'database'
        /// </summary>
        /// <param name="user">username</param>
        /// <param name="hashedandSalted">encryptedpass</param>
        /// <param name="salt">the 'salt'</param>
        public void AddUser(string user, string hashedandSalted,string salt)
        {
            passwordAndUserStorage.Add(user, hashedandSalted);
            passwordAndSaltStorage.Add(hashedandSalted, salt);
        }
        /// <summary>
        /// Gets every detail of the user that stored in the 'database'
        /// </summary>
        /// <param name="user">username</param>
        /// <returns>an array with two string :index 0- encrypted password,index 1-the salt</returns>
        public string[] getUser(string user)
        {
            if(passwordAndUserStorage.ContainsKey(user))
            {
                string hashedAndSaltPass = passwordAndUserStorage[user];
                if (passwordAndSaltStorage.ContainsKey(hashedAndSaltPass))
                {
                    string salt = passwordAndSaltStorage[hashedAndSaltPass];
                    return new string[] { hashedAndSaltPass, salt };
                }
            }
            return null;
        }

    }
}
