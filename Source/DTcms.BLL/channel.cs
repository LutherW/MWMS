using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// ϵͳƵ����
    /// </summary>
    public partial class channel
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.channel dal;

        public channel()
        {
            dal = new DAL.channel(siteConfig.sysdatabaseprefix);
        }

        #region ��������===============================
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ��ѯƵ�������Ƿ����
        /// </summary>
        public bool Exists(string name)
        {
            //��վ��Ŀ¼�µ�һ���ļ����Ƿ�ͬ��
            if (DirPathExists(siteConfig.webpath, name))
            {
                return true;
            }
            //��վ��aspxĿ¼�µ�һ���ļ����Ƿ�ͬ��
            if (DirPathExists(siteConfig.webpath + "/" + DTKeys.DIRECTORY_REWRITE_ASPX + "/", name))
            {
                return true;
            }
            //����ڵ�Ƶ�������Ƿ�ͬ��
            if (dal.Exists(name))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// ������������
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.channel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.channel model)
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
        public Model.channel GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.channel GetModel(string channel_name)
        {
            return dal.GetModel(channel_name);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion

        #region ��չ����===============================
        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// ����Ƶ������
        /// </summary>
        public string GetChannelName(int id)
        {
            return dal.GetChannelName(id);
        }

        /// <summary>
        /// ����Ƶ��ID
        /// </summary>
        public int GetChannelId(string name)
        {
            return dal.GetChannelId(name);
        }

        /// <summary>
        /// ��������
        /// </summary>
        public bool UpdateSort(int id, int sort_id)
        {
            //ȡ��Ƶ��������
            string channel_name = dal.GetChannelName(id);
            if (channel_name == string.Empty)
            {
                return false;
            }
            if (new BLL.navigation().UpdateField("channel_" + channel_name, "sort_id=" + sort_id))
            {
                dal.UpdateField(id, "sort_id=" + sort_id);
                return true;
            }
            return false;
        }
        #endregion

        #region ˽�з���===============================
        /// <summary>
        /// �������Ŀ¼����ָ��·���µ�һ��Ŀ¼�Ƿ�ͬ��
        /// </summary>
        /// <param name="dirPath">ָ����·��</param>
        /// <param name="build_path">����Ŀ¼��</param>
        /// <returns>bool</returns>
        private bool DirPathExists(string dirPath, string build_path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath(dirPath));
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                if (build_path.ToLower() == dir.Name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}