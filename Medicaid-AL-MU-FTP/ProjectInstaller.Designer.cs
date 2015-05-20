namespace Medicaid_AL_MU_FTP
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ALMEDFTPInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.ALMEDFTP = new System.ServiceProcess.ServiceInstaller();
            // 
            // ALMEDFTPInstaller
            // 
            this.ALMEDFTPInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.ALMEDFTPInstaller.Password = null;
            this.ALMEDFTPInstaller.Username = null;
            // 
            // ALMEDFTP
            // 
            this.ALMEDFTP.Description = "Grabs authorized documents and uploads them to Alabama Medicaid via FTP";
            this.ALMEDFTP.DisplayName = "Alabama Medicaid FTP";
            this.ALMEDFTP.ServiceName = "ALMEDFTP";
            this.ALMEDFTP.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ALMEDFTPInstaller,
            this.ALMEDFTP});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller ALMEDFTPInstaller;
        private System.ServiceProcess.ServiceInstaller ALMEDFTP;
    }
}