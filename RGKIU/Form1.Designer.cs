namespace RDP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rdp = new AxMSTSCLib.AxMsTscAxNotSafeForScripting();
            this.cnct_rdp = new System.Windows.Forms.Button();
            this.dcnct_rdp = new System.Windows.Forms.Button();
            this.cnct = new System.Windows.Forms.Button();
            this.dcnct = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.spisok_box = new System.Windows.Forms.ComboBox();
            this.full = new System.Windows.Forms.Button();
            this.ComboGRP = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
            this.SuspendLayout();
            // 
            // rdp
            // 
            this.rdp.Enabled = true;
            this.rdp.Location = new System.Drawing.Point(-4, 48);
            this.rdp.Name = "rdp";
            this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
            this.rdp.Size = new System.Drawing.Size(771, 576);
            this.rdp.TabIndex = 0;
            // 
            // cnct_rdp
            // 
            this.cnct_rdp.Location = new System.Drawing.Point(579, 9);
            this.cnct_rdp.Name = "cnct_rdp";
            this.cnct_rdp.Size = new System.Drawing.Size(75, 30);
            this.cnct_rdp.TabIndex = 90;
            this.cnct_rdp.TabStop = false;
            this.cnct_rdp.Text = "Connect";
            this.cnct_rdp.UseVisualStyleBackColor = true;
            this.cnct_rdp.Click += new System.EventHandler(this.cnct_rdp_Click);
            // 
            // dcnct_rdp
            // 
            this.dcnct_rdp.Location = new System.Drawing.Point(579, 9);
            this.dcnct_rdp.Name = "dcnct_rdp";
            this.dcnct_rdp.Size = new System.Drawing.Size(75, 30);
            this.dcnct_rdp.TabIndex = 2;
            this.dcnct_rdp.Text = "Disconnect";
            this.dcnct_rdp.UseVisualStyleBackColor = true;
            this.dcnct_rdp.Visible = false;
            this.dcnct_rdp.Click += new System.EventHandler(this.dcnct_rdp_Click);
            // 
            // cnct
            // 
            this.cnct.Location = new System.Drawing.Point(11, 8);
            this.cnct.Name = "cnct";
            this.cnct.Size = new System.Drawing.Size(75, 30);
            this.cnct.TabIndex = 90;
            this.cnct.TabStop = false;
            this.cnct.Text = "Connect";
            this.cnct.UseVisualStyleBackColor = true;
            this.cnct.Visible = false;
            this.cnct.Click += new System.EventHandler(this.cnct_Click);
            // 
            // dcnct
            // 
            this.dcnct.Enabled = false;
            this.dcnct.Location = new System.Drawing.Point(92, 8);
            this.dcnct.Name = "dcnct";
            this.dcnct.Size = new System.Drawing.Size(75, 30);
            this.dcnct.TabIndex = 90;
            this.dcnct.TabStop = false;
            this.dcnct.Text = "Disconnect";
            this.dcnct.UseVisualStyleBackColor = true;
            this.dcnct.Visible = false;
            this.dcnct.Click += new System.EventHandler(this.dcnct_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(428, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '●';
            this.textBox2.Size = new System.Drawing.Size(119, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "";
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Location = new System.Drawing.Point(183, 9);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(44, 13);
            this.address.TabIndex = 36;
            this.address.Text = "address";
            this.address.Visible = false;
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.Location = new System.Drawing.Point(183, 25);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(29, 13);
            this.login.TabIndex = 37;
            this.login.Text = "login";
            this.login.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Логин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Пароль";
            // 
            // spisok_box
            // 
            this.spisok_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spisok_box.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.spisok_box.FormattingEnabled = true;
            this.spisok_box.Location = new System.Drawing.Point(252, 14);
            this.spisok_box.Name = "spisok_box";
            this.spisok_box.Size = new System.Drawing.Size(119, 21);
            this.spisok_box.TabIndex = 0;
            // 
            // full
            // 
            this.full.Location = new System.Drawing.Point(675, 9);
            this.full.Name = "full";
            this.full.Size = new System.Drawing.Size(75, 30);
            this.full.TabIndex = 90;
            this.full.TabStop = false;
            this.full.Text = "Full_Screen";
            this.full.UseVisualStyleBackColor = true;
            this.full.Click += new System.EventHandler(this.full_Click);
            // 
            // ComboGRP
            // 
            this.ComboGRP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboGRP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboGRP.FormattingEnabled = true;
            this.ComboGRP.Location = new System.Drawing.Point(26, 14);
            this.ComboGRP.Name = "ComboGRP";
            this.ComboGRP.Size = new System.Drawing.Size(70, 21);
            this.ComboGRP.TabIndex = 91;
            this.ComboGRP.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 47);
            this.Controls.Add(this.ComboGRP);
            this.Controls.Add(this.cnct_rdp);
            this.Controls.Add(this.full);
            this.Controls.Add(this.spisok_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.login);
            this.Controls.Add(this.address);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.cnct);
            this.Controls.Add(this.dcnct);
            this.Controls.Add(this.dcnct_rdp);
            this.Controls.Add(this.rdp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxMSTSCLib.AxMsTscAxNotSafeForScripting rdp;
        private System.Windows.Forms.Button cnct_rdp;
        private System.Windows.Forms.Button dcnct_rdp;
        internal System.Windows.Forms.Button cnct;
        internal System.Windows.Forms.Button dcnct;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Label login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox spisok_box;
        private System.Windows.Forms.Button full;
        private System.Windows.Forms.ComboBox ComboGRP;
    }
}

