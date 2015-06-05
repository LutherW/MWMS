using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// ���ظ���
    /// </summary>
    public partial class article_attach
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.article_attach dal;
        public article_attach()
        {
            dal = new DAL.article_attach(siteConfig.sysdatabaseprefix);
        }

        #region ��������
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����û��Ƿ����ع��ø���
        /// </summary>
        public bool ExistsLog(int attach_id, int user_id)
        {
            return dal.ExistsLog(attach_id, user_id);
        }

        /// <summary>
        /// ��ȡ���ش���
        /// </summary>
        public int GetDownNum(int id)
        {
            return dal.GetDownNum(id);
        }

        /// <summary>
        /// ��ȡ�����ش���
        /// </summary>
        public int GetCountNum(int article_id)
        {
            return dal.GetCountNum(article_id);
        }

        /// <summary>
        /// ����һ�����ظ�����¼
        /// </summary>
        public int AddLog(int user_id, string user_name, int attach_id, string file_name)
        {
            Model.user_attach_log model = new Model.user_attach_log();
            model.user_id = user_id;
            model.user_name = user_name;
            model.attach_id = attach_id;
            model.file_name = file_name;
            model.add_time = DateTime.Now;
            return dal.AddLog(model);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.article_attach GetModel(int id)
        {
            return dal.GetModel(id);
        }

        //ɾ�����µľ��ļ�
        public void DeleteFile(int id, string filePath)
        {
            Model.article_attach model = GetModel(id);
            if (model != null && model.file_path != filePath)
            {
                Utils.DeleteFile(model.file_path);
            }
        }

        #endregion  Method

    }
}