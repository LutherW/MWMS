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
	/// ���ݷ�����:��Ա�۸�
	/// </summary>
    public partial class user_group_price
    {
        private string databaseprefix; //���ݿ����ǰ׺
        public user_group_price(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region ��������===============================
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.user_group_price GetModel(int goods_id, int group_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,article_id,goods_id,group_id,price from " + databaseprefix + "user_group_price ");
            strSql.Append(" where goods_id=@goods_id and group_id=@group_id");
            SqlParameter[] parameters = {
					new SqlParameter("@goods_id", SqlDbType.Int,4),
                    new SqlParameter("@group_id", SqlDbType.Int,4)};
            parameters[0].Value = goods_id;
            parameters[1].Value = group_id;

            Model.user_group_price model = new Model.user_group_price();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.user_group_price DataRowToModel(DataRow row)
        {
            Model.user_group_price model = new Model.user_group_price();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["article_id"] != null && row["article_id"].ToString() != "")
                {
                    model.article_id = int.Parse(row["article_id"].ToString());
                }
                if (row["goods_id"] != null && row["goods_id"].ToString() != "")
                {
                    model.goods_id = int.Parse(row["goods_id"].ToString());
                }
                if (row["group_id"] != null && row["group_id"].ToString() != "")
                {
                    model.group_id = int.Parse(row["group_id"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
            }
            return model;
        }

        #endregion
    }
}

