using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Net;
using System.Linq;
using DTcms.Common;

namespace DTcms.API.Weixin.Common
{
    public class MenuMgr
    {
        /// <summary>
        /// 创建菜单
        /// </summary>
        public Senparc.Weixin.MP.Entities.WxJsonResult CreateMenu(string accessToken, Senparc.Weixin.MP.Entities.Menu.ButtonGroup buttonData)
        {
            var jsonString = JsonHelper.ObjectToJSON(buttonData);
            CookieContainer cookieContainer = null; //new CookieContainer();

            using (MemoryStream ms = new MemoryStream())
            {
                var bytes = Encoding.UTF8.GetBytes(jsonString);
                ms.Write(bytes, 0, bytes.Length);
                ms.Seek(0, SeekOrigin.Begin);

                var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", accessToken);
                var result = Senparc.Weixin.MP.HttpUtility.Post.PostGetJson<Senparc.Weixin.MP.Entities.WxJsonResult>(url, cookieContainer, ms);
                return result;
            }
        }

        /// <summary>
        /// 获取当前菜单，如果菜单不存在，将返回null
        /// </summary>
        public Senparc.Weixin.MP.Entities.GetMenuResult GetMenu(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", accessToken);
            var jsonString = Senparc.Weixin.MP.HttpUtility.RequestUtility.HttpGet(url, Encoding.UTF8);

            Senparc.Weixin.MP.Entities.GetMenuResult finalResult;
            try
            {
                Senparc.Weixin.MP.GetMenuResultFull jsonResult = JsonHelper.JSONToObject<Senparc.Weixin.MP.GetMenuResultFull>(jsonString);
                if (jsonResult.menu == null || jsonResult.menu.button.Count == 0)
                {
                    throw new Senparc.Weixin.MP.WeixinException(jsonResult.errmsg);
                }

                finalResult = GetMenuFromJsonResult(jsonResult);
            }
            catch (Senparc.Weixin.MP.WeixinException ex)
            {
                finalResult = null;
            }

            return finalResult;
        }

        /// <summary>
        /// 根据微信返回的Json数据得到可用的GetMenuResult结果
        /// </summary>
        public Senparc.Weixin.MP.Entities.GetMenuResult GetMenuFromJsonResult(Senparc.Weixin.MP.GetMenuResultFull resultFull)
        {
            Senparc.Weixin.MP.Entities.GetMenuResult result = null;
            try
            {
                //重新整理按钮信息
                Senparc.Weixin.MP.Entities.Menu.ButtonGroup bg = new Senparc.Weixin.MP.Entities.Menu.ButtonGroup();
                foreach (var rootButton in resultFull.menu.button)
                {
                    if (rootButton.name == null)
                    {
                        continue;//没有设置一级菜单
                    }
                    var availableSubButton = rootButton.sub_button.Count(z => !string.IsNullOrEmpty(z.name));//可用二级菜单按钮数量
                    if (availableSubButton == 0)
                    {
                        //底部单击按钮
                        if (rootButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase)
                            && string.IsNullOrEmpty(rootButton.key))
                        {
                            throw new Senparc.Weixin.MP.Exceptions.WeixinMenuException("单击按钮的key不能为空！");
                        }

                        if (rootButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase))
                        {
                            //点击
                            bg.button.Add(new Senparc.Weixin.MP.Entities.Menu.SingleClickButton()
                            {
                                name = rootButton.name,
                                key = rootButton.key,
                                type = rootButton.type
                            });
                        }
                        else
                        {
                            //URL
                            bg.button.Add(new Senparc.Weixin.MP.Entities.Menu.SingleViewButton()
                            {
                                name = rootButton.name,
                                url = rootButton.url,
                                type = rootButton.type
                            });
                        }
                    }
                    else
                    {
                        //底部二级菜单
                        var subButton = new Senparc.Weixin.MP.Entities.Menu.SubButton(rootButton.name);
                        bg.button.Add(subButton);

                        foreach (var subSubButton in rootButton.sub_button)
                        {
                            if (subSubButton.name == null)
                            {
                                continue; //没有设置菜单
                            }

                            if (subSubButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase)
                                && string.IsNullOrEmpty(subSubButton.key))
                            {
                                throw new Senparc.Weixin.MP.Exceptions.WeixinMenuException("单击按钮的key不能为空！");
                            }

                            if (subSubButton.type.Equals("CLICK", StringComparison.OrdinalIgnoreCase))
                            {
                                //点击
                                subButton.sub_button.Add(new Senparc.Weixin.MP.Entities.Menu.SingleClickButton()
                                {
                                    name = subSubButton.name,
                                    key = subSubButton.key,
                                    type = subSubButton.type
                                });
                            }
                            else
                            {
                                //URL
                                subButton.sub_button.Add(new Senparc.Weixin.MP.Entities.Menu.SingleViewButton()
                                {
                                    name = subSubButton.name,
                                    url = subSubButton.url,
                                    type = subSubButton.type
                                });
                            }
                        }
                    }
                }

                if (bg.button.Count < 1)
                {
                    throw new Senparc.Weixin.MP.Exceptions.WeixinMenuException("一级菜单按钮至少为1个！");
                }

                result = new Senparc.Weixin.MP.Entities.GetMenuResult()
                {
                    menu = bg
                };
            }
            catch (Exception ex)
            {
                throw new Senparc.Weixin.MP.Exceptions.WeixinMenuException(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// 获取当前菜单 json
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public string GetMenu2(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", accessToken);
            var jsonString = Senparc.Weixin.MP.HttpUtility.RequestUtility.HttpGet(url, Encoding.UTF8);
            return jsonString;
        }

    }
}