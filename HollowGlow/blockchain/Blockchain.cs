using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HollowGlow.Models;

namespace HollowGlow.blockchain
{

    //class Block
    //{
    //    public Block(string ts, string dat, string hs, int nc)
    //    { timestamp = ts; data = dat; hash = hs; nonce = nc; }

    //    public string timestamp;
    //    public string data;
    //    public string hash;
    //    public int nonce;
    //}


    class Blockchain
    {

        public static List<BlockModel> blockchain = new List<BlockModel>();

        public static BlockModel GenerateGenesis()
        {
            int nonce = 0; 
            string timestamp = Convert.ToString(DateTime.Now);
            while (true)
            {
                string newHash = getHash(timestamp, "genesis", "", nonce); 

                if (newHash.StartsWith(string.Concat(Enumerable.Repeat("0", 1))))
                {
                    System.Diagnostics.Debug.WriteLine("Finded! {0}, nonce - {1}", newHash, nonce);
                    return new BlockModel() { Timestamp = timestamp, Data = "genesis", Hash = newHash, Nonce = nonce };
                }
                
                nonce++;
            }
        }


        public static BlockModel CreateBlock(int? userId = null, string dat = "genesis", string prvHash = "")
        {
            int nonce = 0; 
            string timestamp = Convert.ToString(DateTime.Now);
            while (true)
            {
                string newHash = getHash(timestamp, dat, prvHash, nonce); //Вычисляем хэш, дополнительно передавая число сложности

                if (newHash.StartsWith(string.Concat(Enumerable.Repeat("0", 1))))
                {
                    System.Diagnostics.Debug.WriteLine("Finded! {0}, nonce - {1}", newHash, nonce);
                    return new BlockModel() { Timestamp = timestamp, Data = dat, Hash = newHash, Nonce = nonce, UserId = userId };
                }
                
                nonce++;
            }
        }

        static string getHash(string ts, string dat, string prvHash, int nonce)
        {

            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(ts + dat + prvHash + nonce))
                    .Select(item => item.ToString("x2"))); ;
            }
        }
    }
}
