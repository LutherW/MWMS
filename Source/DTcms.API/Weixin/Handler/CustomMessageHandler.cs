using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Configuration;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities;

namespace DTcms.API.Weixin.Handler
{
    /// <summary>
    /// 自定义MessageHandler
    /// 把MessageHandler作为基类，重写对应请求的处理方法
    /// </summary>
    public partial class CustomMessageHandler : Senparc.Weixin.MP.MessageHandlers.MessageHandler<CustomMessageContext>
    {
        /*
         * 重要提示：v1.5起，MessageHandler提供了一个DefaultResponseMessage的抽象方法，
         * DefaultResponseMessage必须在子类中重写，用于返回没有处理过的消息类型（也可以用于默认消息，如帮助信息等）；
         * 其中所有原OnXX的抽象方法已经都改为虚方法，可以不必每个都重写。若不重写，默认返回DefaultResponseMessage方法中的结果。
         */
        
        public CustomMessageHandler(Stream inputStream, int maxRecordCount = 0)
            : base(inputStream, maxRecordCount)
        {
            //这里设置仅用于测试，实际开发可以在外部更全局的地方设置，
            //比如MessageHandler<MessageContext>.GlobalWeixinContext.ExpireMinutes = 3。
            WeixinContext.ExpireMinutes = 10;
            WeixinContext.MaxRecordCount = 1000;  //最多存储多少条记录
        }

        public override void OnExecuting()
        {
            //测试MessageContext.StorageData
            if (CurrentMessageContext.StorageData == null)
            {
                CurrentMessageContext.StorageData = 0;
            }
            base.OnExecuting();
        }

        public override void OnExecuted()
        {
            base.OnExecuted();
            CurrentMessageContext.StorageData = ((int)CurrentMessageContext.StorageData) + 1;
        }

        /// <summary>
        /// 处理文字请求
        /// </summary>
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            IResponseMessageBase IR = null;
            Common.MessageFunction cmfun = new Common.MessageFunction();
            BLL.weixin_request_rule ruleBLL = new BLL.weixin_request_rule();

            try
            {
                string keywords = requestMessage.Content; //发送了文字信息

                //验证公众账户原始ID是否一致
                if (!cmfun.ExistsOriginalId(requestMessage.ToUserName))
                {
                    new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "none", "验证微帐号与微信原始帐号id不一致，说明【1】配置错误，【2】数据来源有问题", requestMessage.ToUserName);
                    return cmfun.GetResponseMessageTxtByContent(requestMessage, "验证微帐号与微信原始帐号id不一致，可能原因【1】系统配置错误，【2】非法的数据来源");
                }

                int responseType = 0;
                int ruleId = ruleBLL.GetKeywordsRuleId(keywords, out responseType);
                if (ruleId <= 0 || responseType <= 0)
                {
                    new BLL.weixin_response_content().Add(requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "none", "未取到关键词对应的数据", requestMessage.ToUserName);
                    return cmfun.GetResponseMessageTxtByContent(requestMessage, "未找到匹配的关键词");
                }
                switch (responseType)
                {
                    case 1:
                        //发送纯文字
                        IR = cmfun.GetResponseMessageTxt(requestMessage, ruleId);
                        break;
                    case 2:
                        //发送多图文
                        IR = cmfun.GetResponseMessageNews(requestMessage, ruleId);
                        break;
                    case 3:
                        //发送语音
                        IR = cmfun.GetResponseMessageeMusic(requestMessage, ruleId);
                        break;
                    default:
                        break;
                }
                new BLL.weixin_response_content().Add(requestMessage.MsgType.ToString(), requestMessage.FromUserName, requestMessage.CreateTime.ToString(), requestMessage.Content, requestMessage.ToString(), string.Empty);
            }
            catch (Exception ex)
            {

            }
            return IR;
        }

        /// <summary>
        /// 处理位置请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        {
            var locationService = new Common.LocationService();
            var responseMessage = locationService.GetResponseMessage(requestMessage as RequestMessageLocation);
            return responseMessage;
        }

        /// <summary>
        /// 处理图片请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageNews>();
            responseMessage.Articles.Add(new Article()
            {
                Title = "您刚才发送了图片信息",
                Description = "您发送的图片将会显示在边上",
                PicUrl = requestMessage.PicUrl,
                Url = "http://weixin.senparc.com"
            });
            responseMessage.Articles.Add(new Article()
            {
                Title = "第二条",
                Description = "第二条带连接的内容",
                PicUrl = requestMessage.PicUrl,
                Url = "http://weixin.senparc.com"
            });

            return responseMessage;
        }

        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageMusic>();
            //设置音乐信息
            responseMessage.Music.Title = "天籁之音";
            responseMessage.Music.Description = "播放您上传的语音";
            responseMessage.Music.MusicUrl = "http://weixin.senparc.com/Media/GetVoice?mediaId=" + requestMessage.MediaId;
            responseMessage.Music.HQMusicUrl = "http://weixin.senparc.com/Media/GetVoice?mediaId=" + requestMessage.MediaId;
            return responseMessage;
        }
        /// <summary>
        /// 处理视频请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您发送了一条视频信息，ID：" + requestMessage.MediaId;
            return responseMessage;
        }

        /// <summary>
        /// 处理链接消息请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnLinkRequest(RequestMessageLink requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = string.Format(@"您发送了一条连接信息：
Title：{0}
Description:{1}
Url:{2}", requestMessage.Title, requestMessage.Description, requestMessage.Url);
            return responseMessage;
        }

        /// <summary>
        /// 处理事件请求（这个方法一般不用重写，这里仅作为示例出现。除非需要在判断具体Event类型以外对Event信息进行统一操作
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEventRequest(RequestMessageEventBase requestMessage)
        {
            var eventResponseMessage = base.OnEventRequest(requestMessage);//对于Event下属分类的重写方法，见：CustomerMessageHandler_Events.cs
            //TODO: 对Event信息进行统一操作
            return eventResponseMessage;
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            /* 所有没有被处理的消息会默认返回这里的结果，
             * 因此，如果想把整个微信请求委托出去（例如需要使用分布式或从其他服务器获取请求），
             * 只需要在这里统一发出委托请求，如：
             * var responseMessage = MessageAgent.RequestResponseMessage(agentUrl, agentToken, RequestDocument.ToString());
             * return responseMessage;
             */

            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "这条消息来自DefaultResponseMessage。";
            return responseMessage;
        }
    }
}
