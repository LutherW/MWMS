using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DTcms.Model
{
    //AllotGoods
    public class AllotGoods
    {
        public AllotGoods() { }
        public AllotGoods(int storeInOrderId, int storeInGoodsId, int sourceStoreId, int purposeStoreId, 
            decimal count, string remark)
        {
            _sourceStoreId = sourceStoreId;
            _purposeStoreId = purposeStoreId;
            _storeingoodsid = storeInGoodsId;
            _storeinorderid = storeInOrderId;
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
        /// AllotOrderId
        /// </summary>		
        private int _allotorderid;
        public int AllotOrderId
        {
            get { return _allotorderid; }
            set { _allotorderid = value; }
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
        /// SourceStoreId
        /// </summary>		
        private int _sourceStoreId;
        public int SourceStoreId
        {
            get { return _sourceStoreId; }
            set { _sourceStoreId = value; }
        }

        /// <summary>
        /// PurposeStoreId
        /// </summary>		
        private int _purposeStoreId;
        public int PurposeStoreId
        {
            get { return _purposeStoreId; }
            set { _purposeStoreId = value; }
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
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
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
        /// <summary>
        /// Status
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}

