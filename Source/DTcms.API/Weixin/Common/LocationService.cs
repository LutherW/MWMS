using System;
using System.Text;
using System.Collections.Generic;
using Senparc.Weixin.MP.Entities;

namespace DTcms.API.Weixin.Common
{
    public class LocationService
    {
        public IResponseMessageBase GetResponseMessage(RequestMessageLocation requestMessage)
        {
            var responseTextMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseTextMessage.Content = "找不到你查询的内容";
            return responseTextMessage;
        }
    }
}