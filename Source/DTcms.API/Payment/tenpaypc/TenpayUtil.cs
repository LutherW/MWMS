using System;
using System.Xml;
using System.Text;
using System.Web;
using DTcms.Common;

namespace DTcms.API.Payment.tenpaypc
{
	/// <summary>
	/// TenpayUtil ��ժҪ˵����
	/// </summary>
	public class TenpayUtil
	{
        public string tenpay = "1";
        public string partner = ""; //�Ƹ�ͨ�̻���
        public string key  = ""; //�Ƹ�ͨ��Կ;
        public string type = "1"; //�ӿ�����1��ʱ����2��������
        public string return_url = ""; //��ʾ֧��֪ͨҳ��;
        public string notify_url = ""; //֧����ɺ�Ļص�����ҳ��;

        public TenpayUtil()
        {
            //��ȡXML������Ϣ
            string fullPath = Utils.GetMapPath("~/xmlconfig/tenpaypc.config");
            XmlDocument doc = new XmlDocument();
            doc.Load(fullPath);
            XmlNode _partner = doc.SelectSingleNode(@"Root/partner");
            XmlNode _key = doc.SelectSingleNode(@"Root/key");
            XmlNode _type = doc.SelectSingleNode(@"Root/type");
            XmlNode _return_url = doc.SelectSingleNode(@"Root/return_url");
            XmlNode _notify_url = doc.SelectSingleNode(@"Root/notify_url");
            //��ȡվ��������Ϣ
            Model.siteconfig model = new BLL.siteconfig().loadConfig();

            partner = _partner.InnerText;
            key = _key.InnerText;
            type = _type.InnerText;
            return_url = "http://" + HttpContext.Current.Request.Url.Authority.ToLower() + _return_url.InnerText;
            notify_url = "http://" + HttpContext.Current.Request.Url.Authority.ToLower() + _notify_url.InnerText;
        }

		/** ���ַ�������URL���� */
		public string UrlEncode(string instr, string charset)
		{
			//return instr;
			if(instr == null || instr.Trim() == "")
				return "";
			else
			{
				string res;
				
				try
				{
					res = HttpUtility.UrlEncode(instr,Encoding.GetEncoding(charset));

				}
				catch (Exception ex)
				{
					res = HttpUtility.UrlEncode(instr,Encoding.GetEncoding("GB2312"));
				}
				
		
				return res;
			}
		}

		/** ���ַ�������URL���� */
		public string UrlDecode(string instr, string charset)
		{
			if(instr == null || instr.Trim() == "")
				return "";
			else
			{
				string res;
				
				try
				{
					res = HttpUtility.UrlDecode(instr,Encoding.GetEncoding(charset));

				}
				catch (Exception ex)
				{
					res = HttpUtility.UrlDecode(instr,Encoding.GetEncoding("GB2312"));
				}
				
		
				return res;

			}
		}

		/** ȡʱ��������漴��,�滻���׵����еĺ�10λ��ˮ�� */
		public UInt32 UnixStamp()
		{
			TimeSpan ts = DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			return Convert.ToUInt32(ts.TotalSeconds);
		}
		/** ȡ����� */
		public string BuildRandomStr(int length) 
		{
			Random rand = new Random();

			int num = rand.Next();

			string str = num.ToString();

			if(str.Length > length)
			{
				str = str.Substring(0,length);
			}
			else if(str.Length < length)
			{
				int n = length - str.Length;
				while(n > 0)
				{
					str.Insert(0, "0");
					n--;
				}
			}
			
			return str;
		}
	}
}