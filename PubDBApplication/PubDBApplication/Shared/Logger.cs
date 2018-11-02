using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace PubDBApplication.Shared
{
    public static class Logger 
    {
        private static readonly string directory = "PubDB_log";
        private static readonly string filePath = "PubDB" + DateTime.Now.ToString("_yyyy-MM-dd_HH.mm") + ".log";
        public static void Log(string message)
        {
            Environment.CurrentDirectory = System.IO.Path.GetTempPath();
                System.IO.Directory.CreateDirectory(directory);
            Environment.CurrentDirectory = System.IO.Path.GetTempPath() + "\\" + directory;
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                var trace = new StackTrace().GetFrame(1);
                streamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") +" > "+ trace.GetMethod() +" -> "+ message);
                streamWriter.Close();
            }
        }
    }
}