namespace BodgeIt
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownDays = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonAutoAdmin = new System.Windows.Forms.Button();
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.textSalutation = new System.Windows.Forms.TextBox();
            this.textOrgId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboAddress = new System.Windows.Forms.ComboBox();
            this.comboDB = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textReportFilename = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textNCName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.numericUpDownMinutes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDownHours);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDownDays);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 128);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Expire Verified accounts older than:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDownMinutes
            // 
            this.numericUpDownMinutes.Location = new System.Drawing.Point(75, 71);
            this.numericUpDownMinutes.Name = "numericUpDownMinutes";
            this.numericUpDownMinutes.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMinutes.TabIndex = 2;
            this.numericUpDownMinutes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Minutes";
            // 
            // numericUpDownHours
            // 
            this.numericUpDownHours.Location = new System.Drawing.Point(75, 45);
            this.numericUpDownHours.Name = "numericUpDownHours";
            this.numericUpDownHours.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownHours.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hours";
            // 
            // numericUpDownDays
            // 
            this.numericUpDownDays.Location = new System.Drawing.Point(75, 19);
            this.numericUpDownDays.Name = "numericUpDownDays";
            this.numericUpDownDays.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDays.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Days";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textPassword);
            this.groupBox2.Controls.Add(this.textUsername);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textEmail);
            this.groupBox2.Controls.Add(this.textLastName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.buttonAutoAdmin);
            this.groupBox2.Controls.Add(this.textFirstName);
            this.groupBox2.Controls.Add(this.textSalutation);
            this.groupBox2.Controls.Add(this.textOrgId);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 222);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add new user";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Go";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "password";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "username";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(75, 178);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(100, 20);
            this.textPassword.TabIndex = 7;
            this.textPassword.Text = "Registration#";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(75, 151);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(100, 20);
            this.textUsername.TabIndex = 6;
            this.textUsername.Text = "T1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Salutation";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Email";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(75, 125);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(268, 20);
            this.textEmail.TabIndex = 5;
            this.textEmail.Text = "applications@beconsultancy.co.uk";
            // 
            // textLastName
            // 
            this.textLastName.Location = new System.Drawing.Point(75, 98);
            this.textLastName.Name = "textLastName";
            this.textLastName.Size = new System.Drawing.Size(100, 20);
            this.textLastName.TabIndex = 4;
            this.textLastName.Text = "Admin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Last Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "First Name";
            // 
            // buttonAutoAdmin
            // 
            this.buttonAutoAdmin.Location = new System.Drawing.Point(213, 183);
            this.buttonAutoAdmin.Name = "buttonAutoAdmin";
            this.buttonAutoAdmin.Size = new System.Drawing.Size(75, 23);
            this.buttonAutoAdmin.TabIndex = 17;
            this.buttonAutoAdmin.Text = "Add T1-T5";
            this.buttonAutoAdmin.UseVisualStyleBackColor = true;
            this.buttonAutoAdmin.Click += new System.EventHandler(this.buttonAutoAdmin_Click);
            // 
            // textFirstName
            // 
            this.textFirstName.Location = new System.Drawing.Point(75, 72);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(100, 20);
            this.textFirstName.TabIndex = 3;
            this.textFirstName.Text = "Admin";
            // 
            // textSalutation
            // 
            this.textSalutation.Location = new System.Drawing.Point(75, 45);
            this.textSalutation.Name = "textSalutation";
            this.textSalutation.Size = new System.Drawing.Size(100, 20);
            this.textSalutation.TabIndex = 2;
            this.textSalutation.Text = "Mr";
            // 
            // textOrgId
            // 
            this.textOrgId.Location = new System.Drawing.Point(75, 19);
            this.textOrgId.Name = "textOrgId";
            this.textOrgId.Size = new System.Drawing.Size(268, 20);
            this.textOrgId.TabIndex = 0;
            this.textOrgId.Text = "d838cdca-faf7-11e4-86b7-00155d0a1426";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Org ID";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(424, 396);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 10;
            this.button7.Text = "Test";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(473, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Truncate DB && run setup scripts";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(473, 68);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(210, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Get First Org ID";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboAddress
            // 
            this.comboAddress.FormattingEnabled = true;
            this.comboAddress.Items.AddRange(new object[] {
            "http://localhost:9000",
            "http://dev-as-01.bec.local:9000",
            "http://sys-as-01.bec.local:9000"});
            this.comboAddress.Location = new System.Drawing.Point(87, 12);
            this.comboAddress.Name = "comboAddress";
            this.comboAddress.Size = new System.Drawing.Size(235, 21);
            this.comboAddress.TabIndex = 6;
            this.comboAddress.Text = "http://localhost:9000";
            // 
            // comboDB
            // 
            this.comboDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDB.FormattingEnabled = true;
            this.comboDB.Location = new System.Drawing.Point(473, 12);
            this.comboDB.Name = "comboDB";
            this.comboDB.Size = new System.Drawing.Size(235, 21);
            this.comboDB.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.buttonBrowse);
            this.groupBox3.Controls.Add(this.textReportFilename);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.textNCName);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(381, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 146);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Update Latest Ts && Cs Report SELECT MATCHING SERVER && DB ABOVE";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(231, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "1. Create new version";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(231, 73);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(141, 67);
            this.button6.TabIndex = 5;
            this.button6.Text = "2. Upload template && create notifications for all users";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(231, 44);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textReportFilename
            // 
            this.textReportFilename.Location = new System.Drawing.Point(94, 46);
            this.textReportFilename.Name = "textReportFilename";
            this.textReportFilename.Size = new System.Drawing.Size(131, 20);
            this.textReportFilename.TabIndex = 3;
            this.textReportFilename.Text = "c:\\reports\\tc2.mrt";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Report template";
            // 
            // textNCName
            // 
            this.textNCName.Location = new System.Drawing.Point(94, 20);
            this.textNCName.Name = "textNCName";
            this.textNCName.Size = new System.Drawing.Size(131, 20);
            this.textNCName.TabIndex = 1;
            this.textNCName.Text = "TcPublic";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(407, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "DB";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 429);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.comboDB);
            this.Controls.Add(this.comboAddress);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textLastName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textFirstName;
        private System.Windows.Forms.TextBox textSalutation;
        private System.Windows.Forms.TextBox textOrgId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboAddress;
        private System.Windows.Forms.ComboBox comboDB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textReportFilename;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textNCName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonAutoAdmin;
    }
}

