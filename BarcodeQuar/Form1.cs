using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace QuarBarcodeApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Form bileşenlerini oluştur
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Ayarları yükle
            var settings = SettingsManager.LoadSettings();
            if (settings != null)
            {
                txtIp.Text = settings.IpAddress;
                txtPort.Text = settings.Port.ToString();
                cmbKeyboardMethod.SelectedItem = settings.KeyboardMethod;
            }
        }

        // Olay işleyicileri
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new AppSettings
                {
                    IpAddress = txtIp.Text,
                    Port = int.Parse(txtPort.Text),
                    KeyboardMethod = cmbKeyboardMethod.SelectedItem.ToString()
                };
                SettingsManager.SaveSettings(settings);
                MessageBox.Show("Ayarlar kaydedildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ayarlar kaydedilirken bir hata oluştu: {ex.Message}");
            }
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                QuarBarcodeServiceControl.StartService();
                lblDurum.Text = "Servis çalışıyor.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Servis başlatılırken bir hata oluştu: {ex.Message}");
            }
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            try
            {
                QuarBarcodeServiceControl.StopService();
                lblDurum.Text = "Servis durduruldu.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Servis durdurulurken bir hata oluştu: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("sc.exe", $"create binPath= {System.Reflection.Assembly.GetExecutingAssembly().Location} start= auto");
        }

        private void lblDurum_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}