using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DTcms.Model
{
    //StoreInOrder
    public class StoreInOrder
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
        /// Status
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
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
        /// ChargingTime
        /// </summary>		
        private DateTime _chargingtime;
        public DateTime ChargingTime
        {
            get { return _chargingtime; }
            set { _chargingtime = value; }
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
        /// ChargingCount
        /// </summary>		
        private decimal _chargingcount;
        public decimal ChargingCount
        {
            get { return _chargingcount; }
            set { _chargingcount = value; }
        }
        /// <summary>
        /// InspectionNumber
        /// </summary>		
        private string _inspectionnumber;
        public string InspectionNumber
        {
            get { return _inspectionnumber; }
            set { _inspectionnumber = value; }
        }
        /// <summary>
        /// AccountNumber
        /// </summary>		
        private string _accountnumber;
        public string AccountNumber
        {
            get { return _accountnumber; }
            set { _accountnumber = value; }
        }
        /// <summary>
        /// SuttleWeight
        /// </summary>		
        private decimal _suttleweight;
        public decimal SuttleWeight
        {
            get { return _suttleweight; }
            set { _suttleweight = value; }
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
        /// 单价
        /// </summary>
        private IList<StoreInUnitPrice> _unitPrices = new List<StoreInUnitPrice>();
        public IList<StoreInUnitPrice> UnitPrices
        {
            private set { _unitPrices = value; }
            get { return _unitPrices; }
        }

        public void AddUnitPrice(StoreInUnitPrice unitPrices)
        {
            _unitPrices.Add(unitPrices);
        }

        /// <summary>
        /// 费用
        /// </summary>
        private IList<StoreInCost> _storeInCosts = new List<StoreInCost>();
        public IList<StoreInCost> StoreInCosts
        {
            private set { _storeInCosts = value; }
            get { return _storeInCosts; }
        }

        public void AddStoreInCost(StoreInCost storeInCost)
        {
            _storeInCosts.Add(storeInCost);
        }

        /// <summary>
        /// 入库货物
        /// </summary>
        private IList<StoreInGoods> _storeInGoods = new List<StoreInGoods>();
        public IList<StoreInGoods> StoreInGoods
        {
            private set { _storeInGoods = value; }
            get { return _storeInGoods; }
        }

        public void AddStoreInGoods(StoreInGoods storeInGoods)
        {
            _storeInGoods.Add(storeInGoods);
        }
    }
}

