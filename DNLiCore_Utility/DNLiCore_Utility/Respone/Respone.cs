using System;
using System.Collections.Generic;
using System.Text;

namespace DNLiCore_Utility.Respone
{
    public static class ResponeHelper
    {
        public static string ResponeMsg(int code, string msg, Object result=null)
        {
            baseReturnModel model = new baseReturnModel();
            model.code = code;
            model.msg = msg;
            model.result = result;
            return Json.JsonHelper.ConvertModelToString(model);
        }
        public static string ResponeMsg(baseReturnModel model)
        {            
            return Json.JsonHelper.ConvertModelToString(model);
        }
        public static baseReturnModel ResponeMsgModel(int code, string msg="", Object result = null)
        {
            baseReturnModel model = new baseReturnModel();
            model.code = code;
            model.msg = msg;
            model.result = result;
            model.time = DateTime.Now;
            return model;
        }



    }
    public class baseReturnModel
    {
        public int code { get; set; } = 0;
        public string msg { get; set; } = "";
        public Object result { get; set; }
        public DateTime time { get; set; } = DateTime.Now;
    }
}
