using System;
using System.Diagnostics;

namespace QuarBarcodeApp
{
    public static class ServiceInstaller
    {
        public static void InstallService(Form1.ServiceType serviceType)
        {
            string serviceName = $"QuarBarcode{serviceType}Service";
            string servicePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string installCommand = $"create {serviceName} binPath= \"{servicePath}\" start= auto";
            ExecuteCommand("sc.exe", installCommand);
        }

        public static void UninstallService(Form1.ServiceType serviceType)
        {
            string serviceName = $"QuarBarcode{serviceType}Service";
            string uninstallCommand = $"delete {serviceName}";
            ExecuteCommand("sc.exe", uninstallCommand);
        }

        private static void ExecuteCommand(string fileName, string arguments)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                process.WaitForExit();
            }
        }
    }
}