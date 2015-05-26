namespace WebApiProxy.Generator
{
    partial class Generator
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtProjectDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnumsNamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEntitiesNamespace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProxyNamespace = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProjectDirectory
            // 
            this.errorProvider.SetError(this.txtProjectDirectory, "Please select a Folder");
            this.txtProjectDirectory.Location = new System.Drawing.Point(128, 16);
            this.txtProjectDirectory.Name = "txtProjectDirectory";
            this.txtProjectDirectory.ReadOnly = true;
            this.txtProjectDirectory.Size = new System.Drawing.Size(291, 20);
            this.txtProjectDirectory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project Directory:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enums Namespace:";
            // 
            // txtEnumsNamespace
            // 
            this.txtEnumsNamespace.Location = new System.Drawing.Point(128, 120);
            this.txtEnumsNamespace.Name = "txtEnumsNamespace";
            this.txtEnumsNamespace.Size = new System.Drawing.Size(291, 20);
            this.txtEnumsNamespace.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Entities Namespace:";
            // 
            // txtEntitiesNamespace
            // 
            this.txtEntitiesNamespace.Location = new System.Drawing.Point(128, 94);
            this.txtEntitiesNamespace.Name = "txtEntitiesNamespace";
            this.txtEntitiesNamespace.Size = new System.Drawing.Size(291, 20);
            this.txtEntitiesNamespace.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Proxy Namespace:";
            // 
            // txtProxyNamespace
            // 
            this.errorProvider.SetError(this.txtProxyNamespace, "Please enter a value!");
            this.txtProxyNamespace.Location = new System.Drawing.Point(128, 68);
            this.txtProxyNamespace.Name = "txtProxyNamespace";
            this.txtProxyNamespace.Size = new System.Drawing.Size(291, 20);
            this.txtProxyNamespace.TabIndex = 7;
            this.txtProxyNamespace.Text = "Bec.TargetFramework.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Endpoint URL:";
            // 
            // txtEndpoint
            // 
            this.errorProvider.SetError(this.txtEndpoint, "Please enter a value!");
            this.txtEndpoint.Location = new System.Drawing.Point(128, 42);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(291, 20);
            this.txtEndpoint.TabIndex = 9;
            this.txtEndpoint.Text = "http://localhost:9000/api/proxies";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(312, 146);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(107, 23);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "Generate Proxy";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 621);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEndpoint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProxyNamespace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEntitiesNamespace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEnumsNamespace);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProjectDirectory);
            this.Name = "Generator";
            this.Text = "Generator";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProjectDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog selectFolderDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnumsNamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEntitiesNamespace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProxyNamespace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEndpoint;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}