using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace ls
{
    internal class funs
    {
        static class Butter
        {
            public static bool print_emoji;
            public static Regex regex;
        }
        public string GetLast(string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }

        public long Get_files_size_on_folder(string folder)
        {
            string[] files = Directory.GetFiles(folder);
            long length = 0;
            foreach (var File in files)
            {

                length += new System.IO.FileInfo(File).Length;

            }

            return length;
        }
        public long Get_folder_size(string path)
        {
            try
            {

                string[] dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                long totalSize = Get_files_size_on_folder(path);
                foreach (string dir in dirs)
                {
                    DirectoryInfo info = new DirectoryInfo(dir);
                    totalSize += info.EnumerateFiles().Sum(file => file.Length);
                }
                return totalSize;
            }
            catch (UnauthorizedAccessException) { return 0; }
        }
        public string check_emoji(string file)
        {
            if (!Butter.print_emoji)
                return "";
            string emoji = "";
            //emoji
            if (GetLast(file.ToLower(), 3) == ".py")
            {
                emoji = "🐍";
            }
            if (GetLast(file.ToLower(), 4) == ".lnk")
            {
                emoji = "🔗";
            }
            if (GetLast(file.ToLower(), 4) == ".apk")
            {
                emoji = "📱";
            }
            if (GetLast(file.ToLower(), 4) == ".php")
            {
                emoji = "🐘";
            }
            if (GetLast(file.ToLower(), 3) == ".rs")
            {
                emoji = "🦀";
            }
            if (GetLast(file.ToLower(), 3) == ".rb")
            {
                emoji = "💎";
            }
            if (GetLast(file.ToLower(), 4) == ".nim")
            {
                emoji = "👑";
            }
            if (GetLast(file.ToLower(), 4) == ".txt")
            {
                emoji = "📝";
            }
            if (GetLast(file.ToLower(), 5) == ".java" || GetLast(file.ToLower(), 4) == ".jsp" || GetLast(file.ToLower(), 5) == ".jspx")
            {
                emoji = "☕";

            }
            if (GetLast(file.ToLower(), 7) == ".docker")
            {
                emoji = "🐋";

            }
            if (GetLast(file.ToLower(), 3) == ".pl")
            {
                emoji = "🐫";

            }
           

            if (GetLast(file.ToLower(), 4) == ".mp4" || GetLast(file.ToLower(), 4) == ".mov")
            {
                emoji = "🎬";

            }
            if (GetLast(file.ToLower(), 4) == ".cer" || GetLast(file.ToLower(),4) == ".crt" || GetLast(file.ToLower(), 4) == ".key" || GetLast(file.ToLower(), 4) == ".pem")
            {
                emoji = "🔓";

            }
            return emoji;
        }
        public void print_files(HelloWorld.Hello.Options o, string file)
        {
            int mb = 1048576;
            int kb = 1024;
            int gb = 1073741824;
            string[] dark_red_exs = { ".exe",".pdf",".bak", ".zip", ".rar", "pptx", ".tmp", ".jar", ".tar",".png","jpeg",".jpg",".gif" }; // last 4 
            string[] green_exs = { ".csv", "xlam", ".xls", "xlsm", "xlsx",".nim"}; // last 4 
            string[] green2_exs = { "msi", "css", ".py" }; // last 3
            string[] cyan_exs = { ".ps1","docx",".asp",".ico",".psd", ".mov", ".mkv",".avi",".mp4",".mp3", "aspx", ".doc", "docm" }; // last 4
            string[] Magenta_exs = { "json","html" }; // last 4
            string[] yellow_exs = { ".js", "bat",".sh","ejs", "jsx",".ts" }; // last 3
            string[] dark_gray_exs = { "dll", "sys","pdb","bin","sql","wsf","cgi" }; // last 3
            string[] red_exs = { "cpp",".rb", "apk","cer" }; // last 3
            string[] purple_exs = { "php", ".pl", "xml",".cs" }; //  last3
            string[] orange_exs = { ".rs" }; //  last 3
            
            string color = "White";
            string output_size = "";
            // files
            if (dark_red_exs.Contains(GetLast(file, 4)))
            {
                color = "red1";
                
            }
            else if (orange_exs.Contains(GetLast(file.ToLower(), 3)))
            {
                color = "orangered1";

            }
            else if (purple_exs.Contains(GetLast(file.ToLower(), 3)))
            {
                color = "purple3";

            }
            else if (red_exs.Contains(GetLast(file.ToLower(), 3)))
            {
                color = "Red";
                
            }
            else if (yellow_exs.Contains(GetLast(file.ToLower(), 3)))
            {
                color = "Yellow";
                
            }
            else if (dark_gray_exs.Contains(GetLast(file.ToLower(), 3)))
            {
                color = "grey50";
                
            }
            else if (Magenta_exs.Contains(GetLast(file.ToLower(), 4)))
            {
                color = "Magenta";   
            }
            else if (green_exs.Contains(GetLast(file.ToLower(), 4)))
            {
                color = "Green"; 
            }
            else if (green2_exs.Contains(GetLast(file.ToLower(), 3)))
            {
                color = "Green";
            }
            else if (cyan_exs.Contains(GetLast(file.ToLower(), 4)))
            {
                color = "cyan1";
            }
            else
            {
                color = "White";
               
            }
            if (o.size != null)
            {

                long length = new System.IO.FileInfo(file).Length;
                if (o.size.ToUpper() == "KB")
                {
                    output_size = " " + length / kb + " KB";
                }
                if (o.size.ToUpper() == "MB")
                {
                    output_size = " " + length / mb + " MB";
                }
                if (o.size.ToUpper() == "GB")
                {
                    output_size = " " + length / gb + " GB";
                }
            }
            if (o.list == false) {
               
            }
            string emoji = check_emoji(file);
            //Console.WriteLine(file + output_size);
            string file2 = file.Replace("[", "").Replace("]", "");
            if (o.info) {
             AnsiConsole.Markup($"[{color}]{file2} {emoji}{output_size}\n{file_info(o, file)}[/]\n");

            }
            else
            {
                AnsiConsole.Markup($"[{color}]{file2} {emoji}{output_size}{file_info(o, file)}[/]\n");

            }
            Console.ResetColor();
    
    }
        public string file_info(HelloWorld.Hello.Options o,string file) {
            // Creating FileInfo instance  

            if (o.info) {
                FileInfo file_info = new FileInfo(file);

                string output = "";
                output = "Created time: " + file_info.CreationTime + "\n";
                output += "Last write: " + file_info.LastWriteTime + "\n";
                output += "Last Access: " + file_info.LastAccessTime + "";
                

                return output;
            }
            return "";
        }
        public  void handle_files(HelloWorld.Hello.Options o) {

            try
            {
                string[] files = Directory.GetFiles(o.path);
                string file = "";
                int len = 0;
            foreach (var File in files)
            {
                len = file.Length;
                if (o.path == ".")
                    file = File.Replace(".\\", "");
                else
                    file = File;

                    if (o.regex != null)
                    {
                        if (Butter.regex.IsMatch(file))
                            print_files(o, file);
                    }
                    else if(o.find == null && o.regex == null)
                    {
                        print_files(o, file);
                    }
                    else
                    {
                        if(file.Contains(o.find))
                            print_files(o, file);

                    }
                }
                    
            }
            catch (UnauthorizedAccessException) { }
        }

        public void handle_folders(HelloWorld.Hello.Options o) {
            try {
            string[] dirs = Directory.GetDirectories(o.path);

            string dir = "";
                string emoji = "";
                bool writeline = false;
                string size_output = "";
            foreach (string Dir in dirs)

            {
                    writeline = false;

                    if (o.path == ".")
                    dir = Dir.Replace(".\\", "");
                else
                    dir = Dir;
                    if (o.regex != null )
                    {
                        if (Butter.regex.IsMatch(dir))
                            writeline = true;
                    }
                    else if (o.find == null && o.regex == null)
                    {
                        writeline = true;
                    }
                    else
                    {
                        if (dir.Contains(o.find))
                        {
                            writeline = true;
                        }
                    }
                    
                if (o.size != null)
                {
                        
                    int mb = 1048576;
                    int kb = 1024;
                    int gb = 1073741824;
                    long totalsize = Get_folder_size(dir);
                    if (o.size.ToUpper() == "KB")
                            size_output = " " + totalsize / kb + " KB";

                    if (o.size.ToUpper() == "MB")
                            size_output = (" " + totalsize / mb + " MB");

                    if (o.size.ToUpper() == "GB")
                            size_output = (" " + totalsize / gb + " GB");


                    
                    }
                    if (Butter.print_emoji)
                        emoji = "📂";
                    if (writeline)
                    {
                        AnsiConsole.Markup($"[dodgerblue3]{dir} {emoji} {size_output}[/]\n");

                    }
                    if (o.list)
                    {
                        o.path = dir;

                        //handle_files(o);
                        Thread files_thread = new Thread(() => handle_files(o));
                        files_thread.Start();
                        //handle_folders(o);
                        Thread folders_thread = new Thread(() => handle_folders(o));
                        folders_thread.Start();
                    }
                }
        }
            catch (UnauthorizedAccessException) { }
}

        
        public void cmd_checker() {
            if(GetParentProcess().MainWindowTitle.Contains("Command Prompt") || GetParentProcess().MainWindowTitle.Contains("cmd.exe") || GetParentProcess().ProcessName == "VsDebugConsole")
            {
                Butter.print_emoji = false;
            }
            else
            {
                Butter.print_emoji = true;
            }

            
        }
        public void regex_checker(HelloWorld.Hello.Options o)
        {
            Regex rx = new Regex(@"" + o.regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Butter.regex = rx;

        }

        public void run(HelloWorld.Hello.Options o) {

            regex_checker(o);
            cmd_checker();
            // fix find with file type
            if (o.type?.ToLower() == "file" && o.find != null)
                o.type = null;

            if (o.type?.ToLower() == "file")
            {
                //handle_files(o);
                Thread files_thread = new Thread(() => handle_files(o));
                files_thread.Start();
            }
                if (o.type?.ToLower() == "folder")
            {
                //handle_folders(o);
                Thread folders_thread = new Thread(() => handle_folders(o));
                folders_thread.Start();
            }
            if (o.type?.ToLower() != "file" && o.type?.ToLower() != "folder")
            {
                Thread files_thread = new Thread(() => handle_files(o));
                files_thread.Start();
                Thread folders_thread = new Thread(() => handle_folders(o));
                folders_thread.Start();
                //handle_files(o);
                //handle_folders(o);
            }

        }


        private static Process GetParentProcess()
        {
            int iParentPid = 0;
            int iCurrentPid = Process.GetCurrentProcess().Id;

            IntPtr oHnd = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

            if (oHnd == IntPtr.Zero)
                return null;

            PROCESSENTRY32 oProcInfo = new PROCESSENTRY32();

            oProcInfo.dwSize =
            (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(PROCESSENTRY32));

            if (Process32First(oHnd, ref oProcInfo) == false)
                return null;

            do
            {
                if (iCurrentPid == oProcInfo.th32ProcessID)
                    iParentPid = (int)oProcInfo.th32ParentProcessID;
            }
            while (iParentPid == 0 && Process32Next(oHnd, ref oProcInfo));

            if (iParentPid > 0)
                return Process.GetProcessById(iParentPid);
            else
                return null;
        }

        static uint TH32CS_SNAPPROCESS = 2;

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESSENTRY32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        };

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

        [DllImport("kernel32.dll")]
        static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll")]
        static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);
    }
}
