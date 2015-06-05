using System;
using System.Collections.Generic;
using System.Text;
using Senparc.Weixin.MP;

namespace DTcms.API.Weixin.Common
{
    /// <summary>
    /// 负责获取或刷新AccessToken
    /// </summary>
    public class CRMComm
    {
        public CRMComm()
        { }

        BLL.weixin_access_token tokenBLL = new BLL.weixin_access_token(); //账户AccessToken
        BLL.weixin_account accountBLL = new BLL.weixin_account(); //公众平台账户

        /// <summary>
        /// 及时获得access_token值
        /// access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。正常情况下access_token有效期为7200秒，
        /// 重复获取将导致上次获取的access_token失效。
        /// 每日限额获取access_token.我们将access_token保存到数据库里，间隔时间为20分钟，从微信公众平台获得一次。
        /// </summary>
        public string GetAccessToken(out string error)
        {
            string access_token = string.Empty;
            error = string.Empty;
            try
            {
                Model.weixin_account accountModel = accountBLL.GetModel(); //公众平台账户信息
                if (accountModel == null || string.IsNullOrEmpty(accountModel.appid) || string.IsNullOrEmpty(accountModel.appsecret))
                {
                    error = "AppId或者AppSecret未填写,请在补全信息！";
                    return string.Empty;
                }
                //没有找到该账户则获取AccessToKen写入存储1200秒
                if (!tokenBLL.Exists())
                {
                    var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(accountModel.appid, accountModel.appsecret);
                    access_token = result.access_token;
                    tokenBLL.Add(access_token);
                    return access_token;
                }
                //获取公众账户的实体
                Model.weixin_access_token tokenModel = tokenBLL.GetModel();
                //计算时间判断是否过期
                TimeSpan ts = DateTime.Now - tokenModel.add_time;
                double chajunSecond = ts.TotalSeconds;
                if (string.IsNullOrEmpty(tokenModel.access_token) || chajunSecond >= tokenModel.expires_in)
                {
                    //从微信平台重新获得AccessToken
                    var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(accountModel.appid, accountModel.appsecret);
                    access_token = result.access_token;
                    //更新到数据库里的AccessToken
                    tokenModel.access_token = access_token;
                    tokenModel.add_time = DateTime.Now;
                    tokenBLL.Update(tokenModel);

                }
                else
                {
                    access_token = tokenModel.access_token;
                }
            }
            catch (Exception ex)
            {
                error = "获取AccessToken出错:" + ex.Message;
            }
            return access_token;
        }

        /// <summary>
        ///【强制刷新】access_token值
        /// access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。正常情况下access_token有效期为7200秒，
        /// 重复获取将导致上次获取的access_token失效。
        /// 每日限额获取access_token.我们将access_token保存到数据库里，间隔时间为20分钟，从微信公众平台获得一次。
        /// </summary>
        /// <returns></returns>
        public string FlushAccessToken(out string error)
        {
            string access_token = string.Empty;
            error = string.Empty;
            try
            {
                Model.weixin_account accountModel = accountBLL.GetModel(); //公众平台账户信息
                if (string.IsNullOrEmpty(accountModel.appid) || string.IsNullOrEmpty(accountModel.appsecret))
                {
                    error = "AppId或者AppSecret未填写,请在补全信息！";
                    return "";
                }

                var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(accountModel.appid, accountModel.appsecret);
                access_token = result.access_token;

                //没有找到该账户则获取AccessToKen写入存储1200秒
                if (!tokenBLL.Exists())
                {
                    tokenBLL.Add(access_token);
                }
                else
                {
                    //获取公众账户的实体
                    Model.weixin_access_token tokenModel = tokenBLL.GetModel();
                    //更新到数据库里的AccessToken
                    tokenModel.access_token = access_token;
                    tokenModel.add_time = DateTime.Now;
                    tokenBLL.Update(tokenModel);
                }
            }
            catch (Exception ex)
            {
                error = "获得AccessToken出错:" + ex.Message;
            }
            return access_token;
        }

        /// <summary>
        /// 获得所有关注用户的openid字符串(别的方法调用此方法)
        /// </summary>
        private IList<string> BaseUserOpenId(out string error)
        {
            IList<string> ret = new List<string>();

            string access_token = GetAccessToken(out error);
            if (error != "")
            {
                return null;
            }
            Senparc.Weixin.MP.AdvancedAPIs.OpenIdResultJson openidJson = Senparc.Weixin.MP.AdvancedAPIs.User.Get(access_token, string.Empty);
            if (openidJson.count == openidJson.total)
            {
                ret = openidJson.data.openid;
            }
            else
            {
                GetNextUserOpenId(openidJson.next_openid, ret);
            }
            return ret;
        }

        /// <summary>
        /// (基础方法)获得所有关注用户的openid字符串(递归算法)
        /// </summary>
        private void GetNextUserOpenId(string nexOpenid, IList<string> openidList)
        {
            string err = string.Empty;
            string access_token = GetAccessToken(out err);
            Senparc.Weixin.MP.AdvancedAPIs.OpenIdResultJson openidJson = Senparc.Weixin.MP.AdvancedAPIs.User.Get(access_token, nexOpenid);
            if (openidJson == null || openidJson.count <= 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < openidJson.data.openid.Count; i++)
                {
                    openidList.Add(openidJson.data.openid[i]);
                }
                GetNextUserOpenId(openidJson.next_openid, openidList);
            }
        }

    }
}
