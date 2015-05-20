using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMED.Worker
{
    class UtilWorker
    {
        public static string[] Split(string origin, string token)
        {
            return origin.Split(new string[] { token }, StringSplitOptions.None);
        }

        public static string LastInstance(string origin, string token)
        {
            return Split(origin, token).LastOrDefault();
        }

        public static string Remove(string origin, string token)
        {
            return String.Join("", Split(origin,token).Where(s => s != token));
        }

        public static string Before(string origin, string token)
        {
            return Split(origin, token)[0];
        }

        public static string After(string origin, string token)
        {
            return Split(origin, token)[1];
        }
    }
}
