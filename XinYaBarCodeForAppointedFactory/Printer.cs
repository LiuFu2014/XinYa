using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XinYaBarCodeForAppointedFactory
{
    public class Printer
    {
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct OVERLAPPED
        {
            int Internal;
            int InternalHigh;
            int Offset;
            int OffSetHigh;
            int hEvent;
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        int dwShareMode,
        int lpSecurityAttributes,
        int dwCreationDisposition,
        int dwFlagsAndAttributes,
        int hTemplateFile
        );

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool WriteFile(
        int hFile,
        byte[] lpBuffer,
        int nNumberOfBytesToWrite,
        out   int lpNumberOfBytesWritten,
        out   OVERLAPPED lpOverlapped
        );

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool CloseHandle(
        int hObject
        );

        private int iHandle;

        public bool Open()
        {
            iHandle = CreateFile("LPT1:", (uint)FileAccess.ReadWrite, 0, 0, (int)FileMode.Open, 0, 0);
            if (iHandle != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Write(string Mystring)
        {
            if (iHandle != -1)
            {
                int i;
                OVERLAPPED x;
                byte[] mybyte = System.Text.Encoding.Default.GetBytes(Mystring);
                return WriteFile(iHandle, mybyte, mybyte.Length, out i, out x);
            }
            else
            {
                throw new Exception("端口未打开!");
            }
        }

        public bool Close()
        {
            return CloseHandle(iHandle);
        }

    }
}
