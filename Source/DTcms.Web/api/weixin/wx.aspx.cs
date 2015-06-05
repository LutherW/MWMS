using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.API.Weixin.Handler;
using DTcms.Common;

namespace DTcms.Web.api.weixin
{
    public partial class wx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string token = new BLL.weixin_account().GetToken(); //与微信公众账号后台的Token设置保持一致，区分大小写。
            if (string.IsNullOrEmpty(token))
            {
                WriteContent("请先添加公众账户！");
                return;
            }

            //获取微信传送参数
            string signature = Request["signature"];
            string timestamp = Request["timestamp"];
            string nonce = Request["nonce"];
            string echostr = Request["echostr"];

            if (Request.HttpMethod == "GET")
            {
                //GET-仅在微信后台填写URL验证时触发
                if (Senparc.Weixin.MP.CheckSignature.Check(signature, timestamp, nonce, token))
                {
                    WriteContent(echostr); //返回随机字符串则表示验证通过
                }
                else
                {
                    WriteContent("failed:" + signature + ",token:" + token + " " + Senparc.Weixin.MP.CheckSignature.GetSignature(timestamp, nonce, token) + "。" +
                                "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
                }
                Response.End();
            }
            else
            {
                //POST-当有用户想公众账号发送消息时触发
                if (!Senparc.Weixin.MP.CheckSignature.Check(signature, timestamp, nonce, token))
                {
                    WriteContent("参数错误！");
                    return;
                }

                //可以设置每个人上下文消息储存的最大数量，防止内存占用过多，如果该参数小于等于0，则不限制
                var maxRecordCount = 10;

                //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
                var messageHandler = new CustomMessageHandler(Request.InputStream, maxRecordCount);

                try
                {
                    //执行微信处理过程
                    messageHandler.Execute();
                    WriteContent(messageHandler.ResponseDocument.ToString());
                    return;
                }
                catch (Exception ex)
                {
                    //写日志
                    /*using (TextWriter tw = new StreamWriter(Server.MapPath("~/App_Data/Error_" + DateTime.Now.Ticks + ".txt")))
                    {
                        tw.WriteLine(ex.Message);
                        tw.WriteLine(ex.InnerException.Message);
                        if (messageHandler.ResponseDocument != null)
                        {
                            tw.WriteLine(messageHandler.ResponseDocument.ToString());
                        }
                        tw.Flush();
                        tw.Close();
                    }*/
                    WriteContent("");
                }
                finally
                {
                    Response.End();
                }
            }
        }

        /// <summary>
        /// 写入文件流
        /// </summary>
        private void WriteContent(string str)
        {
            Response.Output.Write(str);
        }
    }
}