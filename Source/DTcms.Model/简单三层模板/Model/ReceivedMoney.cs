using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
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
		/// EndChargingTime2
        /// </summary>		
		private DateTime _endchargingtime2;
        public DateTime EndChargingTime2
        {
            get{ return _endchargingtime2; }
            set{ _endchargingtime2 = value; }
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
		/// FactTotalPrice
        /// </summary>		
		private decimal _facttotalprice;
        public decimal FactTotalPrice
        {
            get{ return _facttotalprice; }
            set{ _facttotalprice = value; }
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
		   
	}
}

