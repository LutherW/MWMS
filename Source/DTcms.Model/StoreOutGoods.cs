using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DTcms.Model
{
    //StoreOutGoods
    public class StoreOutGoods
    {
        public StoreOutGoods() { }
        public StoreOutGoods(int storeinorderid, int storeInGoodsId, int storeOutWaitingGoodsId, decimal count, string remark)
        {
            _storeinorderid = storeinorderid;
            _storeingoodsid = storeInGoodsId;
            _storeOutWaitingGoodsId = storeOutWaitingGoodsId;
            _count = count;
            _status = 0;
            _remark = remark;
        }
        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// StoreOutOrderId
        /// </summary>		
        private int _storeoutorderid;
        public int StoreOutOrderId
        {
            get { return _storeoutorderid; }
            set { _storeoutorderid = value; }
        }
        /// <summary>
        /// StoreInOrderId
        /// </summary>		
        private int _storeinorderid;
        public int StoreInOrderId
        {
            get { return _storeinorderid; }
            set { _storeinorderid = value; }
        }
        /// <summary>
        /// StoreInGoodsId
        /// </summary>		
        private int _storeingoodsid;
        public int StoreInGoodsId
        {
            get { return _storeingoodsid; }
            set { _storeingoodsid = value; }
        }
        /// <summary>
        /// StoreInGoodsId
        /// </summary>		
        private int _storeOutWaitingGoodsId;
        public int StoreOutWaitingGoodsId
        {
            get { return _storeOutWaitingGoodsId; }
            set { _storeOutWaitingGoodsId = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        /// <summary>
        /// Status
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// Count
        /// </summary>		
        private decimal _count;
        public decimal Count
        {
            get { return _count; }
            set { _count = value; }
        }

    }
}

