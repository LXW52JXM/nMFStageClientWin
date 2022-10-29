using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    public class StartKeyBoard
    {
        public static bool isShowNumBoard = false;
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);
        public static void StartKeyBoardFun()
        {
            string path = "C:/Program Files/Common Files/microsoft shared/ink/TabTip.exe";
            if (File.Exists(path))
            {
                Process p = Process.Start(path);
            }
            else
            {
                //判断软键盘是否进程是否已经存在，如果不存在进行调用
                Process[] pro = Process.GetProcessesByName("osk");
                //说明已经存在，不再进行调用
                if (pro != null && pro.Length > 0)
                    return;
                IntPtr ptr = new IntPtr();
                bool isWow64FsRedirectionDisabled = Wow64DisableWow64FsRedirection(ref ptr);
                if (isWow64FsRedirectionDisabled)
                {
                    Process.Start(@"C:\WINDOWS\system32\osk.exe");
                    bool isWow64FsRedirectionReverted = Wow64RevertWow64FsRedirection(ptr);
                }
            }
        }

    }
}
