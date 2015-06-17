using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//ReceivedMoney
		public class ReceivedMoney
	{
   		     
      	/// <summary>
		/// Id
        /// </summary>		
		private int _id;
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// StoreInOrderId
        /// </summary>		
		private int _storeinorderid;
        public int StoreInOrderId
        {
            get{ return _storeinorderid; }
            set{ _storeinorderid = value; }
        }        
		/// <summary>
		/// CustomerId
        /// </summary>		
		private int _customerid;
        public int CustomerId
        {
            get{ return _customerid; }
            set{ _customerid = value; }
        }        
		/// <summary>
		/// Name
        /// </summary>		
		private string _name;
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		/// <summary>
		/// BeginChargingTime
        /// </summary>		
		private DateTime _beginchargingtime;
        public DateTime BeginChargingTime
        {
            get{ return _beginchargingtime; }
            set{ _beginchargingtime = value; }
        }        
		/// <summary>
		/// EndChargingTime
        /// </summary>		
		private DateTime _endchargingtime;
        public DateTime EndChargingTime
        {
            get{ return _endchargingtime; }
            set{ _endchargingtime = value; }
        }

        /// <summary>
        /// ReceivedTime
        /// </summary>		
        private DateTime _receivedTime;
        public DateTime ReceivedTime
        {
            get { return _receivedTime; }
            set { _receivedTime = value; }
        } 

		/// <summary>
		/// ChargingCount
        /// </summary>		
		private decimal _chargingcount;
        public decimal ChargingCount
        {
            get{ return _chargingcount; }
            set{ _chargingcount = value; }
        }        
		/// <summary>
		/// TotalPrice
        /// </summary>		
		private decimal _totalprice;
        public decimal TotalPrice
        {
            get{ return _totalprice; }
            set{ _totalprice = value; }
        }
        /// <summary>
        /// InvoicedPrice
        /// </summary>		
        private decimal _invoicedPrice;
        public decimal InvoicedPrice
        {
            get { return _invoicedPrice; }
            set { _invoicedPrice = value; }
        } 

		/// <summary>
		/// CreateTime
        /// </summary>		
		private DateTime _createtime;
        public DateTime CreateTime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		/// <summary>
		/// Admin
        /// </summary>		
		private string _admin;
        public string Admin
        {
            get{ return _admin; }
            set{ _admin = value; }
        }        
		/// <summary>
		/// Remark
        /// </summary>		
		private string _remark;
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        
		/// <summary>
		/// Status
        /// </summary>		
		private int _status;
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }

        /// <summary>
        /// HasBeenInvoiced
        /// </summary>		
        private bool _hasBeenInvoiced;
        public bool HasBeenInvoiced
        {
            get { return _hasBeenInvoiced; }
            set { _hasBeenInvoiced = value; }
        }
        /// <summary>
        /// InvoicedTime
        /// </summary>		
        private DateTime? _invoicedTime;
        public DateTime? InvoicedTime
        {
            get { return _invoicedTime; }
            set { _invoicedTime = value; }
        }
        /// <summary>
        /// InvoicedOperator
        /// </summary>		
        private string _invoicedOperator;
        public string InvoicedOperator
        {
            get { return _invoicedOperator; }
            set { _invoicedOperator = value; }
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
	}
}

