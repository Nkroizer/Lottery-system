using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Threading.Tasks;

namespace Lottery_system.Models
{
    public static class helper
    {
        public static int getScore ()
        {
            string html = string.Empty;
            string url = @"http://www.randomnumberapi.com/api/v1.0/random?min=1&max=1000000";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            string score = html.Replace("[", "").Replace("]", "");
            return Int32.Parse(score);
        }


        public static users getWiner ()
        {
            users winner = new users();
            winner.userName = globalHighScore.highestUser;
            winner.score = globalHighScore.highestScore;
            winner.magic = globalHighScore.highestMagic;

            return winner;
        }


        public static string getMagicNumber(int score)
        {
            return BigInteger.Pow(score, 60000).ToString();
        }
    }
}
