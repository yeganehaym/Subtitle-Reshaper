namespace UnicodeForPersian
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbldir = new System.Windows.Forms.Label();
            this.lblfile = new System.Windows.Forms.Label();
            this.btnconvertdirs = new System.Windows.Forms.Button();
            this.txtdirpath = new System.Windows.Forms.TextBox();
            this.chksubdir = new System.Windows.Forms.CheckBox();
            this.btnopendir = new System.Windows.Forms.Button();
            this.btnopenfile = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbldir
            // 
            this.lbldir.AutoSize = true;
            this.lbldir.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbldir.Location = new System.Drawing.Point(12, 23);
            this.lbldir.Name = "lbldir";
            this.lbldir.Size = new System.Drawing.Size(70, 14);
            this.lbldir.TabIndex = 0;
            this.lbldir.Text = "انتخاب پوشه";
            // 
            // lblfile
            // 
            this.lblfile.AutoSize = true;
            this.lblfile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblfile.Location = new System.Drawing.Point(12, 84);
            this.lblfile.Name = "lblfile";
            this.lblfile.Size = new System.Drawing.Size(107, 14);
            this.lblfile.TabIndex = 1;
            this.lblfile.Text = "انتخاب فایل زیرنویس";
            // 
            // btnconvertdirs
            // 
            this.btnconvertdirs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnconvertdirs.Location = new System.Drawing.Point(577, 19);
            this.btnconvertdirs.Name = "btnconvertdirs";
            this.btnconvertdirs.Size = new System.Drawing.Size(75, 23);
            this.btnconvertdirs.TabIndex = 2;
            this.btnconvertdirs.Text = "تبدیل";
            this.btnconvertdirs.UseVisualStyleBackColor = true;
            this.btnconvertdirs.Click += new System.EventHandler(this.btnconvertdirs_Click);
            // 
            // txtdirpath
            // 
            this.txtdirpath.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtdirpath.Location = new System.Drawing.Point(128, 20);
            this.txtdirpath.Name = "txtdirpath";
            this.txtdirpath.Size = new System.Drawing.Size(362, 22);
            this.txtdirpath.TabIndex = 3;
            // 
            // chksubdir
            // 
            this.chksubdir.AutoSize = true;
            this.chksubdir.Checked = true;
            this.chksubdir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chksubdir.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chksubdir.Location = new System.Drawing.Point(128, 46);
            this.chksubdir.Name = "chksubdir";
            this.chksubdir.Size = new System.Drawing.Size(212, 18);
            this.chksubdir.TabIndex = 6;
            this.chksubdir.Text = "عملیات در زیرپوشه ها هم انجام بگیرد";
            this.chksubdir.UseVisualStyleBackColor = true;
            // 
            // btnopendir
            // 
            this.btnopendir.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnopendir.Location = new System.Drawing.Point(496, 19);
            this.btnopendir.Name = "btnopendir";
            this.btnopendir.Size = new System.Drawing.Size(75, 23);
            this.btnopendir.TabIndex = 7;
            this.btnopendir.Text = "انتخاب";
            this.btnopendir.UseVisualStyleBackColor = true;
            this.btnopendir.Click += new System.EventHandler(this.btnopendir_Click);
            // 
            // btnopenfile
            // 
            this.btnopenfile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnopenfile.Location = new System.Drawing.Point(128, 80);
            this.btnopenfile.Name = "btnopenfile";
            this.btnopenfile.Size = new System.Drawing.Size(172, 23);
            this.btnopenfile.TabIndex = 8;
            this.btnopenfile.Text = "انتخاب و تبدیل";
            this.btnopenfile.UseVisualStyleBackColor = true;
            this.btnopenfile.Click += new System.EventHandler(this.btnopenfile_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(152, 125);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 9;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Visible = true;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(15, 142);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(659, 214);
            this.listBox1.TabIndex = 10;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(22, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "آخرین ارسالی های انجمن پارس نویس";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(435, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "با دو بار کلیک بر روی آیتم ها، صفحه مربوطه را باز کنید.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 367);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnopenfile);
            this.Controls.Add(this.btnopendir);
            this.Controls.Add(this.chksubdir);
            this.Controls.Add(this.txtdirpath);
            this.Controls.Add(this.btnconvertdirs);
            this.Controls.Add(this.lblfile);
            this.Controls.Add(this.lbldir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "ParsNevis Subtitle Reshaper V1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbldir;
        private System.Windows.Forms.Label lblfile;
        private System.Windows.Forms.Button btnconvertdirs;
        private System.Windows.Forms.TextBox txtdirpath;
        private System.Windows.Forms.CheckBox chksubdir;
        private System.Windows.Forms.Button btnopendir;
        private System.Windows.Forms.Button btnopenfile;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}

