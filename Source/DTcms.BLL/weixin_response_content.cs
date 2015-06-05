using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
	/// <summary>
	/// ΢��ƽ̨�ظ���Ϣ
	/// </summary>
	public partial class weixin_response_content
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.weixin_response_content dal;
		public weixin_response_content()
		{
            dal = new DAL.weixin_response_content(siteConfig.sysdatabaseprefix);
        }

        #region ��������===================================
        /// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Model.weixin_response_content model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Model.weixin_response_content model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Model.weixin_response_content GetModel(int id)
		{
			return dal.GetModel(id);
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
		#endregion

        #region ��չ����===================================
        /// <summary>
       /// ����һ����¼
       /// </summary>
       /// <param name="openid">������û�openid</param>
        /// <param name="request_type">�û���������ͣ��ı���Ϣ��text ͼƬ��Ϣ:image ����λ����Ϣ:location ������Ϣ:link �¼�:event</param>
        /// <param name="request_content">�û��������������</param>
        /// <param name="response_type"> ϵͳ�ظ������ͣ��ı���Ϣ��text ,ͼ����Ϣ:txtpic ,����music, ����λ����Ϣ:location ������Ϣ:link,δȡ������none</param>
        /// <param name="reponse_content">ϵͳ�ظ�������</param>
        /// <param name="ToUserName">����ȡ����xml���ݣ����ǽ�toUserName����</param>
        public int Add(string openid, string request_type, string request_content, string response_type, string reponse_content, string xml_content)
        {
            int result = 0;
            try
            {
                Model.weixin_response_content model = new Model.weixin_response_content();
                model.openid = openid;
                model.request_type = request_type;
                model.request_content = request_content;
                model.response_type = response_type;
                model.reponse_content = reponse_content;
                model.xml_content = xml_content;
                model.add_time = DateTime.Now;
                result = dal.Add(model);
            }
            catch
            {
                return 0;
            }
            return result;
        }
        #endregion
    }
}

