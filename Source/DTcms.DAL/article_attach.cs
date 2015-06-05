using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// ���ظ���
    /// </summary>
    public partial class article_attach
    {
        private string databaseprefix; //���ݿ����ǰ׺
        public article_attach(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        #region Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "article_attach");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����û��Ƿ����ع��ø���
        /// </summary>
        public bool ExistsLog(int attach_id, int user_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "user_attach_log");
            strSql.Append(" where attach_id=@attach_id and user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@attach_id", SqlDbType.Int,4),
                    new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = attach_id;
            parameters[1].Value = user_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ��ȡ�����������ش���
        /// </summary>
        public int GetDownNum(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 down_num from " + databaseprefix + "article_attach");
            strSql.Append(" where id=" + id);
            string str = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            return Convert.ToInt32(str);
        }

        /// <summary>
        /// ��ȡ�����ش���
        /// </summary>
        public int GetCountNum(int article_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(down_num) from " + databaseprefix + "article_attach");
            strSql.Append(" where article_id=" + article_id);
            string str = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            return Convert.ToInt32(str);
        }

        /// <summary>
        /// ����һ�����ظ�����¼
        /// </summary>
        public int AddLog(Model.user_attach_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "user_attach_log(");
            strSql.Append("user_id,user_name,attach_id,file_name,add_time)");
            strSql.Append(" values (");
            strSql.Append("@user_id,@user_name,@attach_id,@file_name,@add_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
                    new SqlParameter("@user_name", SqlDbType.VarChar,100),
					new SqlParameter("@attach_id", SqlDbType.Int,4),
					new SqlParameter("@file_name", SqlDbType.VarChar,255),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.attach_id;
            parameters[3].Value = model.file_name;
            parameters[4].Value = model.add_time;

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
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "article_attach set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// ���Ҳ����ڵ��ļ���ɾ����ɾ���ĸ���������
        /// </summary>
        public void DeleteList(SqlConnection conn, SqlTransaction trans, List<Model.article_attach> models, int article_id)
        {
            StringBuilder idList = new StringBuilder();
            if (models != null)
            {
                foreach (Model.article_attach modelt in models)
                {
                    if (modelt.id > 0)
                    {
                        idList.Append(modelt.id + ",");
                    }
                }
            }
            string id_list = Utils.DelLastChar(idList.ToString(), ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,file_path from " + databaseprefix + "article_attach where article_id=" + article_id);
            if (!string.IsNullOrEmpty(id_list))
            {
                strSql.Append(" and id not in(" + id_list + ")");
            }
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int rows = DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "article_attach where id=" + dr["id"].ToString()); //ɾ�����ݿ�
                if (rows > 0)
                {
                    Utils.DeleteFile(dr["file_path"].ToString()); //ɾ���ļ�
                }
            }
        }

        /// <summary>
        /// ɾ�������ļ�
        /// </summary>
        public void DeleteFile(List<Model.article_attach> models)
        {
            if (models != null)
            {
                foreach (Model.article_attach modelt in models)
                {
                    Utils.DeleteFile(modelt.file_path);
                }
            }
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.article_attach GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,article_id,file_name,file_path,file_size,file_ext,down_num,point,add_time from " + databaseprefix + "article_attach ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.article_attach model = new Model.article_attach();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["article_id"].ToString() != "")
                {
                    model.article_id = int.Parse(ds.Tables[0].Rows[0]["article_id"].ToString());
                }
                model.file_name = ds.Tables[0].Rows[0]["file_name"].ToString();
                model.file_path = ds.Tables[0].Rows[0]["file_path"].ToString();
                if (ds.Tables[0].Rows[0]["file_size"].ToString() != "")
                {
                    model.file_size = int.Parse(ds.Tables[0].Rows[0]["file_size"].ToString());
                }
                model.file_ext = ds.Tables[0].Rows[0]["file_ext"].ToString();
                if (ds.Tables[0].Rows[0]["down_num"].ToString() != "")
                {
                    model.down_num = int.Parse(ds.Tables[0].Rows[0]["down_num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["point"].ToString() != "")
                {
                    model.point = int.Parse(ds.Tables[0].Rows[0]["point"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Model.article_attach> GetList(int article_id)
        {
            List<Model.article_attach> modelList = new List<Model.article_attach>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,article_id,file_name,file_path,file_size,file_ext,down_num,point,add_time ");
            strSql.Append(" FROM " + databaseprefix + "article_attach ");
            strSql.Append(" where article_id=" + article_id);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.article_attach model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.article_attach();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["article_id"] != null && dt.Rows[n]["article_id"].ToString() != "")
                    {
                        model.article_id = int.Parse(dt.Rows[n]["article_id"].ToString());
                    }
                    if (dt.Rows[n]["file_name"] != null && dt.Rows[n]["file_name"].ToString() != "")
                    {
                        model.file_name = dt.Rows[n]["file_name"].ToString();
                    }
                    if (dt.Rows[n]["file_path"] != null && dt.Rows[n]["file_path"].ToString() != "")
                    {
                        model.file_path = dt.Rows[n]["file_path"].ToString();
                    }
                    if (dt.Rows[n]["file_ext"] != null && dt.Rows[n]["file_ext"].ToString() != "")
                    {
                        model.file_ext = dt.Rows[n]["file_ext"].ToString();
                    }
                    if (dt.Rows[n]["file_size"] != null && dt.Rows[n]["file_size"].ToString() != "")
                    {
                        model.file_size = int.Parse(dt.Rows[n]["file_size"].ToString());
                    }
                    if (dt.Rows[n]["down_num"] != null && dt.Rows[n]["down_num"].ToString() != "")
                    {
                        model.down_num = int.Parse(dt.Rows[n]["down_num"].ToString());
                    }
                    if (dt.Rows[n]["point"] != null && dt.Rows[n]["point"].ToString() != "")
                    {
                        model.point = int.Parse(dt.Rows[n]["point"].ToString());
                    }
                    if (dt.Rows[0]["add_time"].ToString() != "")
                    {
                        model.add_time = DateTime.Parse(dt.Rows[0]["add_time"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion
    }
}