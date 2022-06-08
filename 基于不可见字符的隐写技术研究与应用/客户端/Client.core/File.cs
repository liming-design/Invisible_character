using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Client.core
{
    public class file
    {
        static FileStream File;
        static StreamReader sr;
        static StreamWriter sw;

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>FileString</returns>
        public static string ReadFromFile(string filepath)
        {
            File = new FileStream(filepath, FileMode.Open, FileAccess.Read);//打开txt文件
            sr = new StreamReader(File, System.Text.Encoding.GetEncoding("unicode"));
            string fileString = sr.ReadToEnd();
            sr.Close();
            File.Close();
            return fileString;
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>FileString</returns>
        public static void WriteToFile(string filepath, string message)
        {
            File = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);//打开txt文件
            sw = new StreamWriter(File, System.Text.Encoding.GetEncoding("unicode"));
            foreach (var s in message)
            {
                sw.Write(s);
            }
            sw.Close();
            File.Close();
        }
    }




}
