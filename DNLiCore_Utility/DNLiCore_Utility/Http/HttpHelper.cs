using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DNLiCore_Utility.Http
{
    public class HttpHelper
    {


        /// <summary>
        /// Post同步请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="postData">请求数据</param>
        /// <param name="contentType">application/xml、application/json、application/text、application/x-www-form-urlencoded</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="headers">填充头部</param>
        /// <returns></returns>
        public static string HttpPost(string url, string postData = null, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage responeModel= HttpPostResponeMsg(url,postData,contentType,timeOut,headers);
            if (responeModel != null)
            {
                return responeModel.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "";
            }            
        }

        public static HttpResponseMessage HttpPostResponeMsg(string url, string postData = null, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            postData = postData ?? "";
            using (HttpClient client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
                {
                    try
                    {
                        if (contentType != null)
                        {
                            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                        }
                        HttpResponseMessage respone = client.PostAsync(url, httpContent).Result;
                        return respone;
                    }
                    catch (Exception)
                    {

                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 发起POST异步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="contentType">application/xml、application/json、application/text、application/x-www-form-urlencoded</param>
        /// <param name="headers">填充消息头</param>        
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, string postData = null, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            postData = postData ?? "";
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, timeOut);
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
                {
                    if (contentType != null)
                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                    HttpResponseMessage response = await client.PostAsync(url, httpContent);
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        /// <summary>
        /// 发起GET同步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static string HttpGet(string url, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage responeModel= HttpGetResponeMsg(url, contentType, timeOut, headers);
            if (responeModel != null)
            {
                return responeModel.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "";
            }            
        }

        public static HttpResponseMessage  HttpGetResponeMsg(string url, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.Timeout = new TimeSpan(0, 0, timeOut);
                    if (contentType != null)
                        client.DefaultRequestHeaders.Add("ContentType", contentType);
                    if (headers != null)
                    {
                        foreach (var header in headers)
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    return response;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }



        /// <summary>
        /// 发起GET异步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, timeOut);
                if (contentType != null)
                    client.DefaultRequestHeaders.Add("ContentType", contentType);
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                HttpResponseMessage response = await client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }
     
    }
}
