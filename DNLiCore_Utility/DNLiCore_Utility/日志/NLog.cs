using System;
using System.Collections.Generic;
using System.Text;

namespace DNLiCore_Utility.Log
{
    public static class NLogHelper
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 信息输出
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            logger.Info(message);
        }
        /// <summary>
        /// 信息输出
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Info(string message,Exception exception)
        {
            logger.Info(exception,message);
        }



        /// <summary>
        /// 警告信息输出
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            logger.Warn(message);
        }
        /// <summary>
        /// 警告信息输出
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Warn(string message, Exception exception)
        {
            logger.Warn(exception, message);
        }


        /// <summary>
        /// 错误信息输出
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            logger.Error(message);
        }
        /// <summary>
        /// 错误信息输出
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception)
        {
            logger.Error(exception, message);
        }

        /// <summary>
        /// 非常严重的错误信息输出
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
        {
            logger.Fatal(message);
        }
        /// <summary>
        /// 非常严重的错误信息输出
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Fatal(string message, Exception exception)
        {
            logger.Fatal(exception, message);
        }


      

    }
}
