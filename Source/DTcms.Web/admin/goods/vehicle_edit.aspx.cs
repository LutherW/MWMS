using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.goods
{
    public partial class vehicle_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //取到操作类型
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.Vehicle().Exists(this.id))
                {
                    JscriptMsg("车辆不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("vehicle_manage", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Vehicle bll = new BLL.Vehicle();
            Model.Vehicle model = bll.GetModel(_id);
            txtPlateNumber.Text = model.PlateNumber;
            txtDriver.Text = model.Driver;
            txtLinkTel.Text = model.LinkTel;
            txtLinkAddress.Text = model.LinkAddress;
            txtRemark.Text = model.Remark;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.Vehicle model = new Model.Vehicle();
            BLL.Vehicle bll = new BLL.Vehicle();

            model.PlateNumber = txtPlateNumber.Text;
            model.Driver = txtDriver.Text;
            model.LinkTel = txtLinkTel.Text;
            model.LinkAddress = txtLinkAddress.Text;
            model.Remark = txtRemark.Text;
            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加车辆:" + model.PlateNumber); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Vehicle bll = new BLL.Vehicle();
            Model.Vehicle model = bll.GetModel(_id);

            model.PlateNumber = txtPlateNumber.Text;
            model.Driver = txtDriver.Text;
            model.LinkTel = txtLinkTel.Text;
            model.LinkAddress = txtLinkAddress.Text;
            model.Remark = txtRemark.Text;
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改车辆:" + model.PlateNumber); //记录日志
                result = true;
            }

            return result;
        }
        #endregion


        // 提交保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("vehicle_manage", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改车辆成功！", "vehicle_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("vehicle_manage", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加车辆成功！", "vehicle_list.aspx");
            }
        }

    }
}