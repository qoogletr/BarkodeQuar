using System.Diagnostics;

public static class BarcodeQuarServiceControl
{
    private static Process serviceProcess;

    public static void StartService()
    {
        if (serviceProcess == null || serviceProcess.HasExited)
        {
            serviceProcess = new Process();
            serviceProcess.StartInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            serviceProcess.StartInfo.Arguments = "service";
            serviceProcess.StartInfo.UseShellExecute = false;
            serviceProcess.StartInfo.CreateNoWindow = true;
            serviceProcess.Start();
        }
    }

    public static void StopService()
    {
        if (serviceProcess != null && !serviceProcess.HasExited)
        {
            serviceProcess.Kill();
        }
    }
}