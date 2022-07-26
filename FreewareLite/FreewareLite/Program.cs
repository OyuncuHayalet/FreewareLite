using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace FreewareLite
{
    class Program
    {
        private static int nbPid = 0;
        private static int javawPid = 0;
        private static Process javaw = null;

        static void Main(string[] args)
        {
            Console.Title = "SonOyuncu ClientSide Xray Protection Disabler";

            Process[] processList = Process.GetProcesses();

            foreach (Process p in processList)
            {
                if (p.ProcessName.Equals("bootstrap"))
                {
                    nbPid = p.Id;
                    break;
                }
            }

            foreach (Process p in processList)
            {
                if (p.ProcessName.Equals("javaw") && p.MainWindowTitle.Equals("SonOyuncu Minecraft Launcher"))
                {
                    javawPid = p.Id;
                    javaw = p;
                    break;
                }
            }

            if (javawPid == 0 || nbPid == 0)
            {
                MessageBox.Show("SonOyuncu Launcheri Açın", "MasterClient Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(-1);
            }

            writer("lwjgl-2.9.4-nightly-20150209.jar lib dosyası editlenecek...", 10);

            using (WebClient web = new WebClient())
            {
                web.DownloadFile("https://raw.githubusercontent.com/OyuncuHayalet/FreewareLite/main/FreewareLite/edit/lwjgl-2.9.4-nightly-20150209.jar", FileUtils.GetAppPath() + "libraries\\lwjgl-2.9.4-nightly-20150209.jar");
                web.Dispose();
            }

            writer("Dosya değiştirildi... SonOyuncu bekleniyor...", 10);
            
            while (FileUtils.Cryptography.GetSHA1(FileUtils.GetAppPath() + "libraries\\lwjgl-2.9.4-nightly-20150209.jar") == "F7AB9BFC1CC59E1BAA357CBDBB965388964CEDA0")
            {
                Thread.Sleep(20);
            }

            using (WebClient web = new WebClient())
            {
                web.DownloadFile("https://raw.githubusercontent.com/OyuncuHayalet/FreewareLite/main/FreewareLite/edit/lwjgl-2.9.4-nightly-20150209.jar", FileUtils.GetAppPath() + "libraries\\lwjgl-2.9.4-nightly-20150209.jar");
                web.Dispose();
            }

            writer("Lib dosyaası editlendi...", 10);
            Thread.Sleep(2000);

        }

        public static void consolewriteline(string text, int delay)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(delay);
            }
            Console.Write("\n");
        }

        public static void errorWriter(string text, int delay)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" [ ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.White;
            consolewriteline(text, delay);
        }

        public static void writer(string text, int delay)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" [ ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.White;
            consolewriteline(text, delay);
        }
    }
}
