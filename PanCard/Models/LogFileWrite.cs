using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PanCard.Models
{
    public static class LogFileWrite
    {
        public static void write(string line)
        {
            string path=HttpContext.Current.Server.MapPath("~/App_Data/log.txt");
            StreamWriter sr = File.AppendText(path);
            sr.WriteLine("{" + line + ",date:" + DateTime.Now.ToString() + "}");
            sr.Close();
        }
    }
}