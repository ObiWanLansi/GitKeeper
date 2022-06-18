using System;
using System.Collections.Generic;
using System.IO;



namespace GitKeeper
{
    static class GitKeeper
    {
        private static readonly string GITKEEP = ".gitkeep";

        private static readonly HashSet<string> IGNORE = new() { "bin", "obj", "packages", "build" };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static bool IgnoreDirectory(DirectoryInfo di) => IGNORE.Contains(di.Name.ToLower());


        private static bool ContainsGitKeep(FileSystemInfo[] childs)
        {
            foreach (FileSystemInfo fi in childs)
            {
                if (fi.Name.Equals(GITKEEP))
                {
                    return true;
                }
            }

            return false;
        }


        private static void ScanDirectory(DirectoryInfo diCurrent)
        {
            Console.Out.WriteLineAsync($"Scanning {diCurrent.FullName}");

            FileSystemInfo[] childs = diCurrent.GetFileSystemInfos();

            if (childs.Length == 0)
            {
                Console.Out.WriteLineAsync($"    The directory '{diCurrent.FullName}' contains no files or subfolders, i'll create an {GITKEEP}");
                File.WriteAllBytes($"{diCurrent.FullName}\\{GITKEEP}", new byte[] { });
                return;
            }

            foreach (DirectoryInfo diChild in diCurrent.GetDirectories())
            {
                if (diChild.Name[0] == '.')
                {
                    continue;
                }

                if (IgnoreDirectory(diChild))
                {
                    continue;
                }

                ScanDirectory(diChild);
            }

            if (ContainsGitKeep(childs) && childs.Length > 1)
            {
                Console.Out.WriteLineAsync($"    The directory '{diCurrent.FullName}' contains an obsolete {GITKEEP}");
                File.Delete($"{diCurrent.FullName}\\{GITKEEP}");
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        static void Main(string[] args) => ScanDirectory(new DirectoryInfo(Environment.CurrentDirectory));
    }
}
