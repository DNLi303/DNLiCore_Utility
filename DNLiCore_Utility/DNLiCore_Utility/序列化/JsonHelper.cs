using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DNLiCore_Utility.Json
{
    public static class JsonHelper
    {

        #region 实体转字符串
        /// <summary>
        /// 实体转字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertModelToString(object value)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value, timejson);
        }
        #endregion

        public static T ConverStringToModel<T>(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value, timejson);
        }

        public static DataTable ConverStringToDataTable(string value)
        {
            return null;
        }

        public static IsoDateTimeConverter timejson = new IsoDateTimeConverter
        {
            DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss"
        };



    }
}
