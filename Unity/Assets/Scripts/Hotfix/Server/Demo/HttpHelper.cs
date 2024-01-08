using System.Net;
using System.Text;

namespace ET.Server
{
    //Http网络帮助类
    public static partial class HttpHelper
    {
        /// <summary>
        /// 回复函数
        /// </summary>
        /// <param name="context"></param>
        /// <param name="response"></param>
        public static void Response(HttpListenerContext context, object response)
        {
            byte[] bytes = MongoHelper.ToJson(response).ToUtf8();
            context.Response.StatusCode = 200;
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.ContentLength64 = bytes.Length;
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }
    }
}