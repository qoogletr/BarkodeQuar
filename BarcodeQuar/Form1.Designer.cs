using System;
using System.Windows.Forms;

namespace QuarBarcodeApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // TextBox ve diğer kontroller
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.ComboBox cmbKeyboardMethod;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Button btnDurdur;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblKeyboardMethod;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtIp = new TextBox();
            txtPort = new TextBox();
            cmbKeyboardMethod = new ComboBox();
            btnKaydet = new Button();
            btnBaslat = new Button();
            btnDurdur = new Button();
            lblDurum = new Label();
            lblIp = new Label();
            lblPort = new Label();
            lblKeyboardMethod = new Label();
            installService = new Button();
            uninstallService = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // txtIp
            // 
            txtIp.Location = new Point(153, 25);
            txtIp.Name = "txtIp";
            txtIp.Size = new Size(184, 23);
            txtIp.TabIndex = 0;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(153, 55);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(184, 23);
            txtPort.TabIndex = 1;
            // 
            // cmbKeyboardMethod
            // 
            cmbKeyboardMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKeyboardMethod.FormattingEnabled = true;
            cmbKeyboardMethod.Items.AddRange(new object[] { "SendKeys", "InputSimulator", "Clipboard" });
            cmbKeyboardMethod.Location = new Point(153, 85);
            cmbKeyboardMethod.Name = "cmbKeyboardMethod";
            cmbKeyboardMethod.Size = new Size(103, 23);
            cmbKeyboardMethod.TabIndex = 2;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(262, 85);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(75, 23);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnBaslat
            // 
            btnBaslat.Location = new Point(143, 190);
            btnBaslat.Name = "btnBaslat";
            btnBaslat.Size = new Size(75, 23);
            btnBaslat.TabIndex = 4;
            btnBaslat.Text = "Başlat";
            btnBaslat.UseVisualStyleBackColor = true;
            btnBaslat.Click += btnBaslat_Click;
            // 
            // btnDurdur
            // 
            btnDurdur.Location = new Point(224, 190);
            btnDurdur.Name = "btnDurdur";
            btnDurdur.Size = new Size(75, 23);
            btnDurdur.TabIndex = 5;
            btnDurdur.Text = "Durdur";
            btnDurdur.UseVisualStyleBackColor = true;
            btnDurdur.Click += btnDurdur_Click;
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(72, 235);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(114, 15);
            lblDurum.TabIndex = 6;
            lblDurum.Text = "Durum: Servis kapalı";
            lblDurum.Click += lblDurum_Click;
            // 
            // lblIp
            // 
            lblIp.AutoSize = true;
            lblIp.Location = new Point(53, 28);
            lblIp.Name = "lblIp";
            lblIp.Size = new Size(56, 15);
            lblIp.TabIndex = 7;
            lblIp.Text = "IP Adresi:";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(53, 58);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(32, 15);
            lblPort.TabIndex = 8;
            lblPort.Text = "Port:";
            // 
            // lblKeyboardMethod
            // 
            lblKeyboardMethod.AutoSize = true;
            lblKeyboardMethod.Location = new Point(53, 88);
            lblKeyboardMethod.Name = "lblKeyboardMethod";
            lblKeyboardMethod.Size = new Size(93, 15);
            lblKeyboardMethod.TabIndex = 9;
            lblKeyboardMethod.Text = "Sümile Yöntemi:";
            // 
            // installService
            // 
            installService.Location = new Point(143, 160);
            installService.Name = "installService";
            installService.Size = new Size(75, 23);
            installService.TabIndex = 10;
            installService.Text = "ServisKur";
            installService.UseVisualStyleBackColor = true;
            installService.Click += button1_Click;
            // 
            // uninstallService
            // 
            uninstallService.Location = new Point(224, 160);
            uninstallService.Name = "uninstallService";
            uninstallService.Size = new Size(75, 23);
            uninstallService.TabIndex = 11;
            uninstallService.Text = "ServisKaldır";
            uninstallService.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 117);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 14;
            label1.Text = "Servis Tipi:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "SendKeys", "InputSimulator", "Clipboard" });
            comboBox1.Location = new Point(153, 114);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(184, 23);
            comboBox1.TabIndex = 12;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            ClientSize = new Size(425, 260);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(uninstallService);
            Controls.Add(installService);
            Controls.Add(lblKeyboardMethod);
            Controls.Add(lblPort);
            Controls.Add(lblIp);
            Controls.Add(lblDurum);
            Controls.Add(btnDurdur);
            Controls.Add(btnBaslat);
            Controls.Add(btnKaydet);
            Controls.Add(cmbKeyboardMethod);
            Controls.Add(txtPort);
            Controls.Add(txtIp);
            Name = "Form1";
            Text = "Quar Barcode Servis Yöneticisi";
            ResumeLayout(false);
            PerformLayout();
        }
        private Button installService;
        private Button uninstallService;
        private Label label1;
        private ComboBox comboBox1;
    }
}