using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace TempFilesDeletingProcess
{
    class Program
    {
        public static string rootPath = string.Empty;
        public static string tempPath = string.Empty;
        public static string destinationPath = string.Empty;
        static void Main(string[] args)
        {
            try
            {
                rootPath = ConfigurationManager.AppSettings["RootPath"];
                tempPath = ConfigurationManager.AppSettings["TempPath"];
                destinationPath = rootPath + tempPath;

                while (true)
                {

                    //get Files

                    string[] files = Directory.GetFiles(destinationPath);

                    if (files == null || files.Length == 0)
                    {
                        System.Console.WriteLine("No Files Found");
                    }
                    else
                    {
                        foreach (string file in files)
                        {
                            File.Delete(file);

                        }
                        System.Console.WriteLine(files.Length + " " + "Files Deleted Successfully.");
                    }
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                throw;
            }
 
        }
    }
}
