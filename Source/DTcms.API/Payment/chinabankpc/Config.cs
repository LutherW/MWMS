using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Xml;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.API.Payment.chinabankpc
{
    public class Config
    {
        #region 字段
        private string partner = string.Empty;
        private string key = string.Empty;
        private string return_url = string.Empty;
        private string notify_url = string.Empty;
        private string input_charset = string.Empty;
        #endregion

        public Config()
        {
            //读取XML配置信息
            string fullPath = Utils.GetMapPath("~/xmlconfig/chinabankpc.config");
            XmlDocument doc = new XmlDocument();
            doc.Load(fullPath);
            XmlNode _partner = doc.SelectSingleNode(@"Root/partner");
            XmlNode _key = doc.SelectSingleNode(@"Root/key");
            XmlNode _return_url = doc.SelectSingleNode(@"Root/return_url");
            XmlNode _notify_url = doc.SelectSingleNode(@"Root/notify_url");
            //读取站点配置信息
            Model.siteconfig model = new BLL.siteconfig().loadConfig();

            //赋值变量值
            partner = _partner.InnerText;
            key = _key.InnerText;
            return_url = "http://" + HttpContext.Current.Request.Url.Authority.ToLower() + _return_url.InnerText;
            notify_url = "http://" + HttpContext.Current.Request.Url.Authority.ToLower() + _notify_url.InnerText;
            input_charset = "utf-8";
        }

        #region 属性
        /// <summary>
        /// 商户编号
        /// </summary>
        public string Partner
        {
            get { return partner; }
            set { partner = value; }
        }

        /// <summary>
        /// 获取或设置交易安全检验码
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// 获取页面跳转同步通知页面路径
        /// </summary>
        public string Return_url
        {
            get { return return_url; }
        }

        /// <summary>
        /// 获取服务器异步通知页面路径
        /// </summary>
        public string Notify_url
        {
            get { return notify_url; }
        }

        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        public string Input_charset
        {
            get { return input_charset; }
        }
        #endregion
    }
}
