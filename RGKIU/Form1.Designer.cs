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
            this.label4 = new System.Windows.Forms.Label();
            this.spisok_box = new System.Windows.Forms.ComboBox();
            this.full = new System.Windows.Forms.Button();
            this.ComboGRP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
            this.SuspendLayout();
            // 
            // rdp
            // 
            resources.ApplyResources(this.rdp, "rdp");
            this.rdp.Name = "rdp";
            this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
            // 
            // cnct_rdp
            // 
            resources.ApplyResources(this.cnct_rdp, "cnct_rdp");
            this.cnct_rdp.Name = "cnct_rdp";
            this.cnct_rdp.TabStop = false;
            this.cnct_rdp.UseVisualStyleBackColor = true;
            this.cnct_rdp.Click += new System.EventHandler(this.cnct_rdp_Click);
            // 
            // dcnct_rdp
            // 
            resources.ApplyResources(this.dcnct_rdp, "dcnct_rdp");
            this.dcnct_rdp.Name = "dcnct_rdp";
            this.dcnct_rdp.UseVisualStyleBackColor = true;
            this.dcnct_rdp.Click += new System.EventHandler(this.dcnct_rdp_Click);
            // 
            // cnct
            // 
            resources.ApplyResources(this.cnct, "cnct");
            this.cnct.Name = "cnct";
            this.cnct.TabStop = false;
            this.cnct.UseVisualStyleBackColor = true;
            this.cnct.Click += new System.EventHandler(this.cnct_Click);
            // 
            // dcnct
            // 
            resources.ApplyResources(this.dcnct, "dcnct");
            this.dcnct.Name = "dcnct";
            this.dcnct.TabStop = false;
            this.dcnct.UseVisualStyleBackColor = true;
            this.dcnct.Click += new System.EventHandler(this.dcnct_Click);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.Tag = "";
            // 
            // address
            // 
            resources.ApplyResources(this.address, "address");
            this.address.Name = "address";
            // 
            // login
            // 
            resources.ApplyResources(this.login, "login");
            this.login.Name = "login";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // spisok_box
            // 
            resources.ApplyResources(this.spisok_box, "spisok_box");
            this.spisok_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spisok_box.FormattingEnabled = true;
            this.spisok_box.Name = "spisok_box";
            this.spisok_box.SelectedIndexChanged += new System.EventHandler(this.spisok_box_SelectedIndexChanged);
            // 
            // full
            // 
            resources.ApplyResources(this.full, "full");
            this.full.Name = "full";
            this.full.TabStop = false;
            this.full.UseVisualStyleBackColor = true;
            this.full.Click += new System.EventHandler(this.full_Click);
            // 
            // ComboGRP
            // 
            resources.ApplyResources(this.ComboGRP, "ComboGRP");
            this.ComboGRP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboGRP.FormattingEnabled = true;
            this.ComboGRP.Name = "ComboGRP";
            this.ComboGRP.SelectedIndexChanged += new System.EventHandler(this.ComboGRP_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboGRP);
            this.Controls.Add(this.cnct_rdp);
            this.Controls.Add(this.full);
            this.Controls.Add(this.spisok_box);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox spisok_box;
        private System.Windows.Forms.Button full;
        private System.Windows.Forms.ComboBox ComboGRP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

