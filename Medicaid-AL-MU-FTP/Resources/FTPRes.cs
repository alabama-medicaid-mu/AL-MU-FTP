using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ALMED.Worker;
using System.Configuration;

namespace ALMED.Resources
{
    class FTPRes
    {
        public string host, path;
        public NetworkCredential cred;

        public FTPRes()
        {
            var s = ConfigurationManager.AppSettings;
            host = s["host"];
            path = s["path"];
            cred = new NetworkCredential(s["user"], s["pass"]);
        }

        public Uri getFileUri(string f)
        {
            return new Uri(host + path + UtilWorker.LastInstance(f, "\\"));
        }

        public Uri getTarget()
        {
            return new Uri(host + path);
        }
    }
}
