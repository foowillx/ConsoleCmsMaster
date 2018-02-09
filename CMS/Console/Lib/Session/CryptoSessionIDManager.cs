using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;

namespace ConsoleCMS.Lib.Session
{
    public class CryptoSessionIDManager : SessionIDManager, ISessionIDManager
    {

        const string Secret = "e8ffc7e56311679f12b6fc91aa77a5eb";

        public override bool Validate(string id)
        {
            bool success = false;

            try
            {
                CryptService crip = new CryptService(CryptProvider.DES);
                crip.Key = Secret;
                string rawGuid = crip.Decrypt(id);
                Guid guid;

                success = Guid.TryParse(rawGuid, out guid);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
            
            return success;
        }

        public override string CreateSessionID(HttpContext context)
        {
            string guid = Guid.NewGuid().ToString();
            
            CryptService crip = new CryptService(CryptProvider.DES);
            crip.Key = Secret;
            string result = crip.Encrypt(guid);
            return result;
        }

    }
}