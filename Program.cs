using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using AppResolution.Models;

namespace AppResolution
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpszClass, string lpszWindow);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out WindowDimension.RECT lpRect);

        static void Main(string[] args)
        {
            var runningApps = GetAppInfo();

            foreach (var app in runningApps.AppResolution)
            {
                var displayInfo = app.Key + " Resolution " + app.Value.Width + " x " + app.Value.Height;
                Console.WriteLine(displayInfo);
            }
        }

        static AppInfo GetAppInfo()
        {
            WindowDimension.RECT rct;
            var appInfo = new AppInfo();
            var tempAppInfo = new Dictionary<string, Resoltion>();

            var runningApps = Process.GetProcesses()
                          .Where(p => (long)p.MainWindowHandle != 0)
                          .ToList();

            foreach (var process in runningApps)
            {
                Rectangle myRect = new Rectangle();

                var processName = process.MainModule.ModuleName;

                var windowName = process.MainWindowTitle;
                var appAddress = FindWindow(null, windowName);
                if (!GetWindowRect(appAddress, out rct))
                {
                    // Can't find window, continue onto the next process
                    continue;
                }

                myRect.Width = rct.Right - rct.Left - 16;
                myRect.Height = rct.Bottom - rct.Top - 16;

                var resolution = new Resoltion(myRect.Width, myRect.Height);
                var fullName = processName + "-" + windowName;

                tempAppInfo.Add(fullName, resolution);
            }

            appInfo.AppResolution = tempAppInfo;

            return appInfo;
        }
    }
}
