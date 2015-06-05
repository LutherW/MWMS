using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
    /// <summary>
    /// ��չ���Ա�
    /// </summary>
    public partial class article_attribute_field
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.article_attribute_field dal;

        public article_attribute_field()
        {
            dal = new DAL.article_attribute_field(siteConfig.sysdatabaseprefix);
        }
        #region  Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ��ѯ�Ƿ������
        /// </summary>
        public bool Exists(string column_name)
        {
            return dal.Exists(column_name);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.article_attribute_field model)
        {
            switch (model.control_type)
            {
                case "single-text": //�����ı�
                    if (model.data_length > 0 && model.data_length <= 4000)
                    {
                        model.data_type = "nvarchar(" + model.data_length + ")";
                    }
                    else if (model.data_length > 4000)
                    {
                        model.data_type = "ntext";
                    }
                    else
                    {
                        model.data_length = 50;
                        model.data_type = "nvarchar(50)";
                    }
                    break;
                case "multi-text": //�����ı�
                    goto case "single-text";
                case "editor": //�༭��
                    model.data_type = "ntext";
                    break;
                case "images": //ͼƬ
                    model.data_type = "nvarchar(255)";
                    break;
                case "video": //��Ƶ
                    model.data_type = "nvarchar(255)";
                    break;
                case "number": //����
                    if (model.data_place > 0)
                    {
                        model.data_type = "decimal(9," + model.data_place + ")";
                    }
                    else
                    {
                        model.data_type = "int";
                    }
                    break;
                case "datetime": //ʱ������
                    model.data_type = "datetime";
                    break;
                case "checkbox": //��ѡ��
                    model.data_type = "tinyint";
                    break;
                case "multi-radio": //���ѡ
                    if (model.data_type == "int")
                    {
                        model.data_length = 4;
                        model.data_type = "int";
                    }
                    else
                    {
                        if (model.data_length > 0 && model.data_length <= 4000)
                        {
                            model.data_type = "nvarchar(" + model.data_length + ")";
                        }
                        else if (model.data_length > 4000)
                        {
                            model.data_type = "ntext";
                        }
                        else
                        {
                            model.data_length = 50;
                            model.data_type = "nvarchar(50)";
                        }
                    }

                    break;
                case "multi-checkbox": //�����ѡ
                    goto case "single-text";
            }
            return dal.Add(model);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.article_attribute_field model)
        {
            switch (model.control_type)
            {
                case "single-text": //�����ı�
                    if (model.data_length > 0 && model.data_length <= 4000)
                    {
                        model.data_type = "nvarchar(" + model.data_length + ")";
                    }
                    else if (model.data_length > 4000)
                    {
                        model.data_type = "ntext";
                    }
                    else
                    {
                        model.data_length = 50;
                        model.data_type = "nvarchar(50)";
                    }
                    break;
                case "multi-text": //�����ı�
                    goto case "single-text";
                case "editor": //�༭��
                    model.data_type = "ntext";
                    break;
                case "images": //ͼƬ
                    model.data_type = "nvarchar(255)";
                    break;
                case "video": //��Ƶ
                    model.data_type = "nvarchar(255)";
                    break;
                case "number": //����
                    if (model.data_place > 0)
                    {
                        model.data_type = "decimal(9," + model.data_place + ")";
                    }
                    else
                    {
                        model.data_type = "int";
                    }
                    break;
                case "datetime": //ʱ������
                    model.data_type = "datetime";
                    break;
                case "checkbox": //��ѡ��
                    model.data_type = "tinyint";
                    break;
                case "multi-radio": //���ѡ
                    if (model.data_type == "int")
                    {
                        model.data_length = 4;
                        model.data_type = "int";
                    }
                    else
                    {
                        if (model.data_length > 0 && model.data_length <= 4000)
                        {
                            model.data_type = "nvarchar(" + model.data_length + ")";
                        }
                        else if (model.data_length > 4000)
                        {
                            model.data_type = "ntext";
                        }
                        else
                        {
                            model.data_length = 50;
                            model.data_type = "nvarchar(50)";
                        }
                    }

                    break;
                case "multi-checkbox": //�����ѡ
                    goto case "single-text";
            }
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
        public Model.article_attribute_field GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Model.article_attribute_field> GetModelList(int channel_id, string strWhere)
        {
            DataSet ds = dal.GetList(channel_id, strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Model.article_attribute_field> DataTableToList(DataTable dt)
        {
            List<Model.article_attribute_field> modelList = new List<Model.article_attribute_field>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.article_attribute_field model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.article_attribute_field();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.name = dt.Rows[n]["name"].ToString();
                    model.title = dt.Rows[n]["title"].ToString();
                    model.control_type = dt.Rows[n]["control_type"].ToString();
                    model.data_type = dt.Rows[n]["data_type"].ToString();
                    if (dt.Rows[n]["data_length"].ToString() != "")
                    {
                        model.data_length = int.Parse(dt.Rows[n]["data_length"].ToString());
                    }
                    if (dt.Rows[n]["data_place"].ToString() != "")
                    {
                        model.data_place = int.Parse(dt.Rows[n]["data_place"].ToString());
                    }
                    model.item_option = dt.Rows[n]["item_option"].ToString();
                    model.default_value = dt.Rows[n]["default_value"].ToString();
                    if (dt.Rows[n]["is_required"].ToString() != "")
                    {
                        model.is_required = int.Parse(dt.Rows[n]["is_required"].ToString());
                    }
                    if (dt.Rows[n]["is_password"].ToString() != "")
                    {
                        model.is_password = int.Parse(dt.Rows[n]["is_password"].ToString());
                    }
                    if (dt.Rows[n]["is_html"].ToString() != "")
                    {
                        model.is_html = int.Parse(dt.Rows[n]["is_html"].ToString());
                    }
                    if (dt.Rows[n]["editor_type"].ToString() != "")
                    {
                        model.editor_type = int.Parse(dt.Rows[n]["editor_type"].ToString());
                    }
                    model.valid_tip_msg = dt.Rows[n]["valid_tip_msg"].ToString();
                    model.valid_error_msg = dt.Rows[n]["valid_error_msg"].ToString();
                    model.valid_pattern = dt.Rows[n]["valid_pattern"].ToString();
                    if (dt.Rows[n]["sort_id"].ToString() != "")
                    {
                        model.sort_id = int.Parse(dt.Rows[n]["sort_id"].ToString());
                    }
                    if (dt.Rows[n]["is_sys"].ToString() != "")
                    {
                        model.is_sys = int.Parse(dt.Rows[n]["is_sys"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ���Ƶ����Ӧ������
        /// </summary>
        public DataSet GetList(int channel_id, string strWhere)
        {
            return dal.GetList(channel_id, strWhere);
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
    }
}