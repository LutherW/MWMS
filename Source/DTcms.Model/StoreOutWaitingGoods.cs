using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// StoreOutWaitingGoods:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StoreOutWaitingGoods
    {
        public StoreOutWaitingGoods()
        { }
        #region Model
        private int _id;
        private DateTime _createtime;
        private DateTime _storingouttime;
        private DateTime? _storedouttime;
        private string _admin;
        private int _status;
        private string _remark;
        private int _storeingoodsid;
        private int _goodsid;
        private int _storeinorderid;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StoringOutTime
        {
            set { _storingouttime = value; }
            get { return _storingouttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StoredOutTime
        {
            set { _storedouttime = value; }
            get { return _storedouttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Admin
        {
            set { _admin = value; }
            get { return _admin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StoreInGoodsId
        {
            set { _storeingoodsid = value; }
            get { return _storeingoodsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GoodsId
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StoreInOrderId
        {
            set { _storeinorderid = value; }
            get { return _storeinorderid; }
        }
        #endregion Model

    }
}
