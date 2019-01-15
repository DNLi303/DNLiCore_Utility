using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DNLiCore_Utility.Log
{
    public static class FileTxtLogs
    {
        /// <summary>
        /// 日志目录
        /// </summary>
        public static string LogPath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + DateTime.Now.ToString("yyyy-MM-dd");

        #region "写文件日志"

        /// <summary>
        /// 写操作日志文件
        /// </summary>
        /// <param name="input">日志内容</param>
        /// <returns></returns>
        public static bool WriteLog(string input)
        {
            return WriteLog(input, "AppError");
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <returns></returns>
        public static void Warnings(string strInput)
        {
            WriteLog(strInput, "Warnings");
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <returns></returns>
        public static void ErrorLog(string strInput)
        {
            WriteLog(strInput, "error");
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <returns></returns>
        public static void Debug(string strInput)
        {
            WriteLog(strInput, "Debug");
        }

        /// <summary>
        /// 写操作日志文件
        /// </summary>
        /// <param name="input">日志内容</param>
        /// <param name="FileName">日志文件名</param>
        /// <returns>返回值true成功,false失败</returns>
        public static bool WriteLog(string input, string FileName)
        {
            bool rBool = true;

            try
            {
                string filePath;

                // 路径不存在则创建
                if (!System.IO.Directory.Exists(LogPath))
                    System.IO.Directory.CreateDirectory(LogPath);

                filePath = System.IO.Path.Combine(LogPath, DateTime.Now.ToString("yyyy-MM-dd_") + FileName + "Log.txt");
                FileInfo logFile = new FileInfo(filePath);
                if (logFile.Exists)
                {
                    if (logFile.Length >= 800000)
                    {
                        logFile.CopyTo(filePath.Replace("Log.txt", DateTime.Now.Ticks + "Log.txt"));
                        File.Delete(filePath);
                    }
                }

                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
                StreamWriter w = new StreamWriter(fs, Encoding.UTF8);
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0:yyyy'/'MM'/'dd' 'HH':'mm':'ss':'fff}", DateTime.Now);
                sb.Append("|");
                sb.Append(input.Replace("\r", "").Replace("\n", "<br />"));
                //sb.Append("|");
                //sb.Append(Common.StringDispose.GetClientIP());
                //sb.Append("|");
                //sb.Append(Common.StringDispose.urlDispose());
                sb.Append("\r\n");
                w.Write(sb.ToString());
                w.Flush();
                w.Close();
                w.Dispose();
                fs.Close();
                fs.Dispose();
            }
            catch
            {
                rBool = false;
            }

            return rBool;
        }

        #endregion

        #region "读取文件日志"

        /// <summary>
        /// 读取文件日志
        /// </summary>
        /// <returns></returns>
        public static List<FileTxtLogsTable> GetFileTxtLogs()
        {
            //System.IO.Path.Combine(LogPath, DateTime.Now.ToString("yyyyMMdd") + FileName + "Log.txt");
            string FilePath = "";
            if (GetFileList().Count > 0)
                FilePath = System.IO.Path.Combine(LogPath, GetFileList().Values[0]);
            return GetFileTxtLogs(FilePath);

        }

        /// <summary>
        /// 读取文件日志
        /// </summary>
        /// <param name="FilePath">文件物理路径</param>
        /// <returns></returns>
        public static List<FileTxtLogsTable> GetFileTxtLogs(string FilePath)
        {
            List<FileTxtLogsTable> lst = new List<FileTxtLogsTable>();
            string LogFileTxt = LoadFile(FilePath);

            string[] lines = LogFileTxt.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] fields;
            for (int i = 0; i < lines.Length; i++)
            {
                fields = lines[i].Split('|');
                lst.Add(new FileTxtLogsTable(DateTime.Parse(fields[0].Trim()), fields[1], fields[2], fields[3]));
            }

            return lst;
        }

        #endregion

        #region "文件操作"

        /// <summary>
        ///返回文件内容.
        /// </summary>
        /// <param name="path">文件件物理路径</param>
        /// <returns>文件内容</returns>
        public static string LoadFile(string path)
        {
            if (!File.Exists(path)) return "";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (fs == null) throw new IOException("Unable to open the file: " + path);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string res = sr.ReadToEnd();
            sr.Close();
            return res;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path">文件物理路径</param>
        /// <returns></returns>
        public static bool DeleteFile(string path)
        {
            bool rBool = false;

            try
            {
                FileInfo fil = new FileInfo(path);
                fil.Delete();
                rBool = true;
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }

            return rBool;
        }

        #endregion

        #region "读取日志文件列表"

        /// <summary>
        /// 获取日志目录下文件列表
        /// </summary>
        /// <returns></returns>
        public static SortedList<MyDateTime, string> GetFileList()
        {
            SortedList<MyDateTime, string> FileList = new SortedList<MyDateTime, string>();
            DirectoryInfo dirInfo = new DirectoryInfo(LogPath);

            foreach (FileSystemInfo var in dirInfo.GetFileSystemInfos())
            {
                if (var.Attributes != FileAttributes.Directory)
                    FileList.Add(new MyDateTime(var.LastWriteTime), var.Name);
            }

            return FileList;
        }

        /// <summary>
        /// 自定义日期类(实现倒排序)
        /// </summary>
        public class MyDateTime : IComparable
        {
            /// <summary>
            /// 日期
            /// </summary>
            public DateTime s_DateTime;
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="d"></param>
            public MyDateTime(DateTime d)
            {
                s_DateTime = d;
            }

            /// <summary>
            /// 重写比较类
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public int CompareTo(object o)
            {
                MyDateTime Two = o as MyDateTime;
                if (Two.s_DateTime > s_DateTime)
                    return 1;
                else if (Two.s_DateTime < s_DateTime)
                    return -1;
                else
                    return 0;
            }
        }

        #endregion
    }
}

