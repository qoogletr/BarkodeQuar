using System;
using System.Runtime.InteropServices;
using System.Text;

public static class KeyboardSimulator
{
    public static void SimulateKeyPress(string text, KeyboardApiType apiType)
    {
        if (apiType == KeyboardApiType.SendInput)
        {
            foreach (char c in text)
            {
                SendKey(c);
            }
        }
        else
        {
            throw new NotSupportedException("Only SendInput is supported.");
        }
    }

    private static void SendKey(char key)
    {
        // Klavye girişini simüle etmek için Windows API'lerini kullan
        INPUT[] inputs = new INPUT[2];

        // Tuşa basma işlemi
        inputs[0].type = (int)InputType.INPUT_KEYBOARD;

        inputs[0].u.ki.wVk = 0; // Sanal tuş kodu (0, Unicode karakter kullanılacağını belirtir)
        inputs[0].u.ki.wScan = (ushort)key; // Unicode karakter
        inputs[0].u.ki.dwFlags = KEYEVENTF_UNICODE; // Unicode karakter gönder

        // Tuşu bırakma işlemi
        inputs[1].type = (int)InputType.INPUT_KEYBOARD;
        inputs[1].u.ki.wVk = 0; // Sanal tuş kodu (0, Unicode karakter kullanılacağını belirtir)
        inputs[1].u.ki.wScan = (ushort)key; // Unicode karakter
        inputs[1].u.ki.dwFlags = KEYEVENTF_UNICODE | KEYEVENTF_KEYUP; // Unicode karakter gönder ve tuşu bırak

        // Girişleri gönder
        uint result = SendInput(2, inputs, Marshal.SizeOf(typeof(INPUT)));
        if (result == 0)
        {
            throw new Exception("Failed to send input.");
        }
    }

    // Windows API'leri
    private const int KEYEVENTF_UNICODE = 0x0004;
    private const int KEYEVENTF_KEYUP = 0x0002;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

    private struct INPUT
    {
        public int type;
        public InputUnion u;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct InputUnion
    {
        [FieldOffset(0)]
        public MOUSEINPUT mi;
        [FieldOffset(0)]
        public KEYBDINPUT ki;
        [FieldOffset(0)]
        public HARDWAREINPUT hi;
    }

    private struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    private struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    private struct HARDWAREINPUT
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }

    private enum InputType
    {
        INPUT_MOUSE = 0,
        INPUT_KEYBOARD = 1,
        INPUT_HARDWARE = 2
    }
}

public enum KeyboardApiType
{
    SendInput,
    OtherMethod
}