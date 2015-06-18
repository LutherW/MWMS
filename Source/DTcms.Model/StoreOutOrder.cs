using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DTcms.Model
{
    //StoreOutOrder
    public class StoreOutOrder
    {

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
        /// CustomerId
        /// </summary>		
        private int _customerid;
        public int CustomerId
        {
            get { return _customerid; }
            set { _customerid = value; }
        }
        /// <summary>
        /// StoreInUnitPriceStoreInOrderId
        /// </summary>		
        private int _storeinorderid;
        public int StoreInOrderId
        {
            get { return _storeinorderid; }
            set { _storeinorderid = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

        private DateTime _storingOutTime;
        public DateTime StoringOutTime
        {
            get { return _storingOutTime; }
            set { _storingOutTime = value; }
        }
        private DateTime? _storedOutTime;
        public DateTime? StoredOutTime
        {
            get { return _storedOutTime; }
            set { _storedOutTime = value; }
        }

        /// <summary>
        /// Admin
        /// </summary>		
        private string _admin;
        public string Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }
        /// <summary>
        /// TotalMoney
        /// </summary>		
        private decimal _totalmoney;
        public decimal TotalMoney
        {
            get { return _totalmoney; }
            set { _totalmoney = value; }
        }
        private decimal _count;
        public decimal Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// <summary>
        /// InvoiceMoney
        /// </summary>		
        private decimal _invoicemoney;
        public decimal InvoiceMoney
        {
            get { return _invoicemoney; }
            set { _invoicemoney = value; }
        }
        /// <summary>
        /// HasBeenInvoiced
        /// </summary>		
        private bool _hasbeeninvoiced;
        public bool HasBeenInvoiced
        {
            get { return _hasbeeninvoiced; }
            set { _hasbeeninvoiced = value; }
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
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// BeginChargingTime
        /// </summary>		
        private DateTime _beginchargingtime;
        public DateTime BeginChargingTime
        {
            get { return _beginchargingtime; }
            set { _beginchargingtime = value; }
        }
        /// <summary>
        /// EndChargingTime
        /// </summary>		
        private DateTime _endchargingtime;
        public DateTime EndChargingTime
        {
            get { return _endchargingtime; }
            set { _endchargingtime = value; }
        }
        /// <summary>
        /// UnitPriceDetails
        /// </summary>		
        private string _unitPriceDetails;
        public string UnitPriceDetails
        {
            get { return _unitPriceDetails; }
            set { _unitPriceDetails = value; }
        } 


        /// <summary>
        /// 费用
        /// </summary>
        private IList<StoreOutCost> _storeOutCosts = new List<StoreOutCost>();
        public IList<StoreOutCost> StoreOutCosts
        {
            private set { _storeOutCosts = value; }
            get { return _storeOutCosts; }
        }

        public void AddStoreInCost(StoreOutCost storeOutCost)
        {
            _storeOutCosts.Add(storeOutCost);
        }

        /// <summary>
        /// 入库货物
        /// </summary>
        private IList<StoreOutGoods> _storeOutGoods = new List<StoreOutGoods>();
        public IList<StoreOutGoods> StoreOutGoods
        {
            private set { _storeOutGoods = value; }
            get { return _storeOutGoods; }
        }

        public void AddStoreOutGoods(StoreOutGoods storeOutGoods)
        {
            _storeOutGoods.Add(storeOutGoods);
        }
    }
}

