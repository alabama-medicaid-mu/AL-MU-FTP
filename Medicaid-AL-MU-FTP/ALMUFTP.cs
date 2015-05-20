using ALMED.Resources;
using ALMED.Worker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Medicaid_AL_MU_FTP
{
    public partial class ALMUFTP : ServiceBase
    {
        System.Timers.Timer timer;
        DateTime scheduleTime;
        static EventLog logger;
        public ALMUFTP(string[] args)
        {
            InitializeComponent();

            string eventSourceName = "EventSource"; 
            string logName = "ALMEDFTP Log"; 

            if (args.Count() > 0) 
                eventSourceName = args[0]; 

            if (args.Count() > 1) 
                logName = args[1]; 
            
            eventLog = new System.Diagnostics.EventLog(); 

            if (!System.Diagnostics.EventLog.SourceExists(eventSourceName)) 
                System.Diagnostics.EventLog.CreateEventSource(eventSourceName, logName); 
            
            eventLog.Source = eventSourceName; 
            eventLog.Log = logName;

            logger = eventLog;

            timer = new System.Timers.Timer();
            scheduleTime = DateTime.Today.AddDays(1).AddHours(9);
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("Service Started");
            timer.Enabled = true;
            timer.Interval = 60000;
            timer.Interval = scheduleTime.Subtract(DateTime.Now).TotalSeconds * 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerElapsed);
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("Service Stopping");
        }

        protected void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UploadFromFolder();

            if (timer.Interval != 24 * 60 * 60 * 1000)
                timer.Interval = 24 * 60 * 60 * 1000;
        }

        protected void UploadFromFolder()
        {
            string[] files = Directory.GetFiles(ConfigurationManager.AppSettings["local"], "*.*", SearchOption.AllDirectories);
            FTPWorker.UploadFiles(this, new FTPRes(), files);
        }

        public void writeEntry(string entry)
        {
            logger.WriteEntry(entry);
        }
    }
}
