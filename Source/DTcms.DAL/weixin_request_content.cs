using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	/// <summary>
    /// ���ݷ�����:����ظ����
	/// </summary>
	public partial class weixin_request_content
	{
        private string databaseprefix; //���ݿ����ǰ׺
        public weixin_request_content(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

        /// <summary>
		/// �Ƿ���ڹ���ü�¼
		/// </summary>
        public bool Exists(int rule_id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "weixin_request_content");
            strSql.Append(" where rule_id=@rule_id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = rule_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// �õ�һ���������ʵ��
		/// </summary>
		public Model.weixin_request_content GetModel(int rule_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 id,account_id,rule_id,title,content,link_url,img_url,media_url,meida_hd_url,sort_id,add_time");
            strSql.Append(" from " + databaseprefix + "weixin_request_content");
            strSql.Append(" where rule_id=@rule_id");
			SqlParameter[] parameters = {
					new SqlParameter("@rule_id", SqlDbType.Int,4)};
            parameters[0].Value = rule_id;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

        // <summary>
        /// ��ù�������б�
        /// </summary>
        public DataSet GetList(int Top, int ruleId, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,account_id,rule_id,title,content,link_url,img_url,media_url,meida_hd_url,sort_id,add_time");
            strSql.Append(" FROM " + databaseprefix + "weixin_request_content where rule_id=" + ruleId);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by sort_id asc,id desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ع���ĵ�һ������
        /// </summary>
        public string GetTitle(int rule_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "weixin_request_content");
            strSql.Append(" where rule_id=@rule_id");
            SqlParameter[] parameters = {
					new SqlParameter("@rule_id", SqlDbType.Int,4)};
            parameters[0].Value = rule_id;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return obj.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// ���ع���ĵ�һ������
        /// </summary>
        public string GetContent(int rule_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 content from " + databaseprefix + "weixin_request_content");
            strSql.Append(" where rule_id=@rule_id");
            SqlParameter[] parameters = {
					new SqlParameter("@rule_id", SqlDbType.Int,4)};
            parameters[0].Value = rule_id;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return obj.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// ���ع����������������
        /// </summary>
        public int GetCount(int rule_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from " + databaseprefix + "weixin_request_content");
            strSql.Append(" where rule_id=@rule_id");
            SqlParameter[] parameters = {
					new SqlParameter("@rule_id", SqlDbType.Int,4)};
            parameters[0].Value = rule_id;
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.weixin_request_content DataRowToModel(DataRow row)
        {
            Model.weixin_request_content model = new Model.weixin_request_content();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["account_id"] != null && row["account_id"].ToString() != "")
                {
                    model.account_id = int.Parse(row["account_id"].ToString());
                }
                if (row["rule_id"] != null && row["rule_id"].ToString() != "")
                {
                    model.rule_id = int.Parse(row["rule_id"].ToString());
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["content"] != null)
                {
                    model.content = row["content"].ToString();
                }
                if (row["link_url"] != null)
                {
                    model.link_url = row["link_url"].ToString();
                }
                if (row["img_url"] != null)
                {
                    model.img_url = row["img_url"].ToString();
                }
                if (row["media_url"] != null)
                {
                    model.media_url = row["media_url"].ToString();
                }
                if (row["meida_hd_url"] != null)
                {
                    model.meida_hd_url = row["meida_hd_url"].ToString();
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["add_time"] != null && row["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(row["add_time"].ToString());
                }
            }
            return model;
        }
    }
}

