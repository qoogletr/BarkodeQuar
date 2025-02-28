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
            LoadServiceTypes();
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
                cmbServiceType.SelectedItem = settings.ServiceType.ToString();
            }
        }

        private void LoadServiceTypes()
        {
            cmbServiceType.Items.AddRange(Enum.GetNames(typeof(ServiceType)));
        }

        // Olay işleyicileri
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new BarcodeQuarAppSettings
                {
                    IpAddress = txtIp.Text,
                    Port = int.Parse(txtPort.Text),
                    KeyboardMethod = cmbKeyboardMethod.SelectedItem.ToString(),
                    ServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), cmbServiceType.SelectedItem.ToString())
                };
                BarcodeQuarSettingsManager.SaveSettings(settings);
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
                var selectedServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), cmbServiceType.SelectedItem.ToString());
                BarcodeQuarServiceControl.StartService(selectedServiceType);
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
                var selectedServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), cmbServiceType.SelectedItem.ToString());
                BarcodeQuarServiceControl.StopService(selectedServiceType);
                lblDurum.Text = "Servis durduruldu.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Servis durdurulurken bir hata oluştu: {ex.Message}");
            }
        }

        private void btnInstallService_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), cmbServiceType.SelectedItem.ToString());
                ServiceInstaller.InstallService(selectedServiceType);
                MessageBox.Show("Servis başarıyla kuruldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Servis kurulurken bir hata oluştu: {ex.Message}");
            }
        }

        private void btnUninstallService_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), cmbServiceType.SelectedItem.ToString());
                ServiceInstaller.UninstallService(selectedServiceType);
                MessageBox.Show("Servis başarıyla kaldırıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Servis kaldırılırken bir hata oluştu: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("sc.exe", $"create binPath= {System.Reflection.Assembly.GetExecutingAssembly().Location} start= auto");
        }

        private void lblDurum_Click(object sender, EventArgs e)
        {
            // Boş olay işleyici
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Boş olay işleyici
        }

        public enum ServiceType
        {
            HTTP,
            Socket
        }
    }
}