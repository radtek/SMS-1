﻿namespace Bec.TargetFramework.SB.Hosts.SBService
{
    partial class SBService
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
            this.eventLog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog)).BeginInit();
            // 
            // eventLog
            // 
            this.eventLog.EnableRaisingEvents = true;
            this.eventLog.Log = "Application";
            this.eventLog.Source = "Bec.TargetFramework.SB.Hosts.SBService";
            // 
            // SBService
            // 
            this.CanShutdown = true;
            this.ServiceName = "Bec.TargetFramework.SB.Hosts.SBService";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog eventLog;
    }
}
