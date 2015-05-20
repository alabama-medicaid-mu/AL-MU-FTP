using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Medicaid_AL_MU_FTP
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {

        protected override void OnBeforeInstall(IDictionary savedState) 
        {
            string parameter = "EventSource\" \"ALMEDFTP Log"; 
            Context.Parameters["assemblypath"] = "\"" + Context.Parameters["assemblypath"] + "\" \"" + parameter + "\""; 
            base.OnBeforeInstall(savedState); 
        }

        public ProjectInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string targetDirectory = Context.Parameters["targetdir"];
            string param1 = Context.Parameters["Param1"], param2 = Context.Parameters["Param2"];
            string exePath = string.Format("{0}Medicaid-AL-MU-FTP.exe", targetDirectory);

            Configuration config = ConfigurationManager.OpenExeConfiguration(exePath);

            config.AppSettings.Settings["path"].Value = string.Format("{0}{1}/", config.AppSettings.Settings["path"].Value, param1);
            config.AppSettings.Settings["local"].Value = param2;

            config.Save();

            ServiceController controller = new ServiceController("ALMEDFTP");
            controller.Start();
        }
    }
}
