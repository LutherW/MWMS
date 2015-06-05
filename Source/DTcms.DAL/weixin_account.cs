using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	/// <summary>
	/// ���ݷ�����:����ƽ̨�˻�
	/// </summary>
	public partial class weixin_account
	{
        private string databaseprefix; //���ݿ����ǰ׺
        public weixin_account(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

        #region ��������================================
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "weixin_account");
            return DbHelperSQL.Exists(strSql.ToString());
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Model.weixin_account model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "weixin_account(");
            strSql.Append("name,originalid,wxcode,token,appid,appsecret,is_push,sort_id,add_time)");
            strSql.Append(" values (");
            strSql.Append("@name,@originalid,@wxcode,@token,@appid,@appsecret,@is_push,@sort_id,@add_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@originalid", SqlDbType.NVarChar,50),
					new SqlParameter("@wxcode", SqlDbType.NVarChar,50),
					new SqlParameter("@token", SqlDbType.NVarChar,300),
					new SqlParameter("@appid", SqlDbType.NVarChar,100),
					new SqlParameter("@appsecret", SqlDbType.NVarChar,150),
					new SqlParameter("@is_push", SqlDbType.TinyInt,1),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.originalid;
            parameters[2].Value = model.wxcode;
            parameters[3].Value = model.token;
            parameters[4].Value = model.appid;
            parameters[5].Value = model.appsecret;
            parameters[6].Value = model.is_push;
            parameters[7].Value = model.sort_id;
            parameters[8].Value = model.add_time;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Model.weixin_account model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "weixin_account set ");
            strSql.Append("name=@name,");
            strSql.Append("originalid=@originalid,");
            strSql.Append("wxcode=@wxcode,");
            strSql.Append("token=@token,");
            strSql.Append("appid=@appid,");
            strSql.Append("appsecret=@appsecret,");
            strSql.Append("is_push=@is_push,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("add_time=@add_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@originalid", SqlDbType.NVarChar,50),
					new SqlParameter("@wxcode", SqlDbType.NVarChar,50),
					new SqlParameter("@token", SqlDbType.NVarChar,300),
					new SqlParameter("@appid", SqlDbType.NVarChar,100),
					new SqlParameter("@appsecret", SqlDbType.NVarChar,150),
					new SqlParameter("@is_push", SqlDbType.TinyInt,1),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.originalid;
            parameters[2].Value = model.wxcode;
            parameters[3].Value = model.token;
            parameters[4].Value = model.appid;
            parameters[5].Value = model.appsecret;
            parameters[6].Value = model.is_push;
            parameters[7].Value = model.sort_id;
            parameters[8].Value = model.add_time;
            parameters[9].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
        public bool Delete()
        {
            int rows = DbHelperSQL.ExecuteSql("delete from " + databaseprefix + "weixin_account");

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public Model.weixin_account GetModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,name,originalid,wxcode,token,appid,appsecret,is_push,sort_id,add_time");
            strSql.Append(" from " + databaseprefix + "weixin_account ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
		#endregion

        #region ��չ����================================
        /// <summary>
        /// �����˻�����
        /// </summary>
        public string GetName()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 name from " + databaseprefix + "weixin_account");
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return string.Empty;
            }
            return title;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.weixin_account DataRowToModel(DataRow row)
        {
            Model.weixin_account model = new Model.weixin_account();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["originalid"] != null)
                {
                    model.originalid = row["originalid"].ToString();
                }
                if (row["wxcode"] != null)
                {
                    model.wxcode = row["wxcode"].ToString();
                }
                if (row["token"] != null)
                {
                    model.token = row["token"].ToString();
                }
                if (row["appid"] != null)
                {
                    model.appid = row["appid"].ToString();
                }
                if (row["appsecret"] != null)
                {
                    model.appsecret = row["appsecret"].ToString();
                }
                if (row["is_push"] != null && row["is_push"].ToString() != "")
                {
                    model.is_push = int.Parse(row["is_push"].ToString());
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

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public string GetToken()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 token from " + databaseprefix + "weixin_account");

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return obj.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// �����˻���ԭʼID�Ƿ��Ӧ
        /// </summary>
        public bool ExistsOriginalId(string originalid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "weixin_account");
            strSql.Append(" where originalid=@originalid");
            SqlParameter[] parameters = {
                    new SqlParameter("@originalid", SqlDbType.NVarChar,50)};
            parameters[0].Value = originalid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion
    }
}

