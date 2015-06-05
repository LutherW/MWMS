using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Diagnostics;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities;

namespace DTcms.API.Weixin.Common
{
    /// <summary>
    /// 处理事件的方法
    /// </summary>
    public partial class MessageFunction
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //站点配置

        #region 处理关注/取消/默认回复方法===========================
        /// <summary>
        /// 定阅事件的统一处理
        /// </summary>
        public IResponseMessageBase EventSubscribe(int type, RequestMessageEventBase requestMessage)
        {
            string EventName = "";

            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }

            if (!ExistsOriginalId(requestMessage.ToUserName))
            {
                //验证接收方是否为我们系统配置的帐号，即验证微帐号与微信原始帐号id是否一致，如果不一致，说明【1】配置错误，【2】数据来源有问题
                new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "none", "未取到关键词对应的数据", requestMessage.ToUserName);
                return GetResponseMessageTxtByContent(requestMessage, "验证微帐号与微信原始帐号id不一致，可能原因【1】系统配置错误，【2】非法的数据来源");
            }


            int responseType = 0;
            int ruleId = new BLL.weixin_request_rule().GetRuleIdAndResponseType("request_type=" + type, out responseType);
            if (ruleId <= 0 || responseType <= 0)
            {
                new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "none", "未取到关键词对应的数据", requestMessage.ToUserName);
                return null;
            }

            IResponseMessageBase reponseMessage = null;
            switch (responseType)
            {
                case 1:
                    //发送纯文字
                    reponseMessage = GetResponseMessageTxt(requestMessage, ruleId);
                    break;
                case 2:
                    //发送多图文
                    reponseMessage = GetResponseMessageNews(requestMessage, ruleId);
                    break;
                case 3:
                    //发送语音
                    reponseMessage = GetResponseMessageeMusic(requestMessage, ruleId);
                    break;
                default:
                    break;
            }
            return reponseMessage;
        }
        #endregion

        #region 请求为文本的处理=====================================
        /// <summary>
        /// 推送纯文字
        /// </summary>
        public IResponseMessageBase GetResponseMessageTxt(RequestMessageText requestMessage, int ruleId)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            responseMessage.Content = new BLL.weixin_request_content().GetContent(ruleId);
            new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName);
            return responseMessage;
        }

        /// <summary>
        /// 推送纯文字
        /// </summary>
        public IResponseMessageBase GetResponseMessageTxtByContent(RequestMessageText requestMessage, string content)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = content;
            new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", "文字请求，推送纯粹文字，内容为：" + content, requestMessage.ToUserName);
            return responseMessage;
        }

        /// <summary>
        /// 处理语音请求
        /// </summary>
        public IResponseMessageBase GetResponseMessageeMusic(RequestMessageText requestMessage, int ruleId)
        {
            string EventName = "";
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageMusic>(requestMessage);
            Model.weixin_request_content model = new BLL.weixin_request_content().GetModel(ruleId);
            if (model == null)
            {
                new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "-1", requestMessage.ToUserName);
            }
            else
            {
                if (model.media_url.Contains("http://"))
                {
                    responseMessage.Music.MusicUrl = model.media_url;

                }
                else
                {
                    //因为安装目录是以/开头，所以去掉，以免出现双斜杆
                    responseMessage.Music.MusicUrl = siteConfig.weburl + "/" + siteConfig.webpath.Replace("/", "") + model.media_url;
                }
                responseMessage.Music.Title = model.title;
                responseMessage.Music.Description = model.content;
                new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "音乐链接：" + model.media_url + "|标题：" + model.title + "|描述：" + model.content, requestMessage.ToUserName);

            }
            return responseMessage;
        }

        /// <summary>
        /// 推送多图文
        /// </summary>
        public IResponseMessageBase GetResponseMessageNews(RequestMessageText requestMessage, int ruleId)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();

            Article article;
            List<Article> artList = new List<Article>();
            IList<Model.weixin_request_content> twList = new BLL.weixin_request_content().GetModelList(10, ruleId, string.Empty);
            foreach (Model.weixin_request_content modelt in twList)
            {
                article = new Article();
                article.Title = modelt.title;
                article.Description = modelt.content;
                article.Url = GetWXApiUrl(modelt.link_url, token, openid);
                if (string.IsNullOrEmpty(modelt.img_url))
                {
                    article.PicUrl = string.Empty;
                }
                else
                {
                    if (modelt.img_url.Contains("http://"))
                    {
                        article.PicUrl = modelt.img_url;

                    }
                    else
                    {
                        //因为安装目录是以/开头，所以去掉，以免出现双斜杆
                        article.PicUrl = siteConfig.weburl + "/" + siteConfig.webpath.Replace("/", "") + modelt.img_url;
                    }
                }
                artList.Add(article);
            }

            if (artList.Count == 0)
            {
                new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "txtpic", "-1", requestMessage.ToUserName);
            }
            else
            {
                new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "txtpic", "这次发了" + artList.Count + "条图文", requestMessage.ToUserName);
            }
            responseMessage.Articles.AddRange(artList);
            return responseMessage;
        }
        #endregion

        #region 请求为事件的处理=====================================
        /// <summary>
        /// 推送纯文字
        /// </summary>
        public IResponseMessageBase GetResponseMessageTxt(RequestMessageEventBase requestMessage, int ruleId)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            responseMessage.Content = new BLL.weixin_request_content().GetContent(ruleId);

            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }

            new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "text", responseMessage.Content, requestMessage.ToUserName);

            return responseMessage;
        }

        /// <summary>
        /// 推送纯文字
        /// </summary>
        public IResponseMessageBase GetResponseMessageTxtByContent(RequestMessageEventBase requestMessage, string content)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            var locationService = new LocationService();
            responseMessage.Content = content;
            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }
            new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "text", "事件：推送纯粹的文字，内容为:" + content, requestMessage.ToUserName);

            return responseMessage;
        }

        /// <summary>
        /// 处理语音请求
        /// </summary>
        public IResponseMessageBase GetResponseMessageeMusic(RequestMessageEventBase requestMessage, int ruleId)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageMusic>(requestMessage);
            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }

            Model.weixin_request_content model = new BLL.weixin_request_content().GetModel(ruleId);
            if (model == null)
            {

                new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "-1", requestMessage.ToUserName);
            }
            else
            {
                if (model.media_url.Contains("http://"))
                {
                    responseMessage.Music.MusicUrl = model.media_url;

                }
                else
                {
                    //因为安装目录是以/开头，所以去掉，以免出现双斜杆
                    responseMessage.Music.MusicUrl = siteConfig.weburl + "/" + siteConfig.webpath.Replace("/", "") + model.media_url;
                }
                responseMessage.Music.Title = model.title;
                responseMessage.Music.Description = model.content;
                new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "音乐链接：" + model.media_url + "|标题：" + model.title + "|描述：" + model.content, requestMessage.ToUserName);
            }
            return responseMessage;
        }

        /// <summary>
        /// 推送多图文
        /// </summary>
        public IResponseMessageBase GetResponseMessageNews(RequestMessageEventBase requestMessage, int ruleId)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();

            Article article;
            List<Article> artList = new List<Article>();
            IList<Model.weixin_request_content> twList = new BLL.weixin_request_content().GetModelList(10, ruleId, string.Empty);
            foreach (Model.weixin_request_content modelt in twList)
            {
                article = new Article();
                article.Title = modelt.title;
                article.Description = modelt.content;
                article.Url = GetWXApiUrl(modelt.link_url, token, openid);
                if (string.IsNullOrEmpty(modelt.img_url))
                {
                    article.PicUrl = string.Empty;
                }
                else
                {
                    if (modelt.img_url.Contains("http://"))
                    {
                        article.PicUrl = modelt.img_url;

                    }
                    else
                    {
                        //因为安装目录是以/开头，所以去掉，以免出现双斜杆
                        article.PicUrl = siteConfig.weburl + "/" + siteConfig.webpath.Replace("/", "") + modelt.img_url;
                    }
                }
                artList.Add(article);
            }

            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }

            if (artList.Count == 0)
            {
                new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "txtpic", "-1", requestMessage.ToUserName);
            }
            else
            {
                new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "txtpic", "这次发了" + artList.Count + "条图文", requestMessage.ToUserName);
            }
            responseMessage.Articles.AddRange(artList);
            return responseMessage;
        }
        #endregion

        #region 获取验证公众账户ID===================================
        /// <summary>
        /// 验证公众账户原始ID是否一致
        /// </summary>
        public bool ExistsOriginalId(string originalId)
        {
            return new BLL.weixin_account().ExistsOriginalId(originalId);
        }
        #endregion

        #region 常用的方法封装=======================================
        /// <summary>
        /// 拼接微信URL地址参数
        /// </summary>
        public string GetWXApiUrl(string url, string token, string openid)
        {
            if (url.Contains("?"))
            {
                return url + "&token=" + token + "&openid=" + openid;
            }
            return url + "?token=" + token + "&openid=" + openid;
        }

        /// <summary>
        /// 设置微信url地址的后缀
        /// </summary>
        /// <returns></returns>
        public string GetWxUrlSuffix()
        {
            return "wxref=mp.weixin.qq.com";
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        public long ConvertDateTimeInt(System.DateTime time)
        {
            long intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (long)(time - startTime).TotalSeconds;
            return intResult;
        }
        #endregion
    }
}
