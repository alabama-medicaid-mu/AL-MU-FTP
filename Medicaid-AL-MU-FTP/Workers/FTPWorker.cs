using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using ALMED.Resources;
using Medicaid_AL_MU_FTP;

namespace ALMED.Worker
{
    class FTPWorker
    {
        public static void UploadFiles(ALMUFTP caller, FTPRes ftpres, string[] paths)
        {
            caller.writeEntry(EnsureDirectory(ftpres));
            using (WebClient client = new WebClient())
            {
                client.Credentials = ftpres.cred;

                foreach (string path in paths)
                {
                    try
                    {client.UploadFile(ftpres.getFileUri(path), path);}
                    catch(Exception e)
                    {
                        caller.writeEntry(e.StackTrace);
                        throw;
                    }
                }
            }
        }

        private static string EnsureDirectory(FTPRes ftpres)
        {
            string returner;
            try
            {
                WebRequest req = WebRequest.Create(ftpres.getTarget());
                req.Method = WebRequestMethods.Ftp.MakeDirectory;
                req.Credentials = ftpres.cred;
                WebResponse res = req.GetResponse();
                returner = res.ToString();
            }
            catch(Exception e)
            {
                returner = e.StackTrace;
            }
            return returner;
        }
       
    }
}
