using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
	 	//StoreOutCost
		public class StoreOutCost
	{
   		     
      	/// <summary>
		/// StoreOutOrderId
        /// </summary>		
		private int _storeoutorderid;
        public int StoreOutOrderId
        {
            get{ return _storeoutorderid; }
            set{ _storeoutorderid = value; }
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
		/// Count
        /// </summary>		
		private decimal _count;
        public decimal Count
        {
            get{ return _count; }
            set{ _count = value; }
        }        
		/// <summary>
		/// UnitPrice
        /// </summary>		
		private decimal _unitprice;
        public decimal UnitPrice
        {
            get{ return _unitprice; }
            set{ _unitprice = value; }
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
		/// Status
        /// </summary>		
		private int _status;
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
		/// <summary>
		/// PaidTime
        /// </summary>		
		private DateTime _paidtime;
        public DateTime PaidTime
        {
            get{ return _paidtime; }
            set{ _paidtime = value; }
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
		/// Customer
        /// </summary>		
		private string _customer;
        public string Customer
        {
            get{ return _customer; }
            set{ _customer = value; }
        }        
		/// <summary>
		/// HasBeenInvoiced
        /// </summary>		
		private bool _hasbeeninvoiced;
        public bool HasBeenInvoiced
        {
            get{ return _hasbeeninvoiced; }
            set{ _hasbeeninvoiced = value; }
        }        
		/// <summary>
		/// InvoicedTime
        /// </summary>		
		private DateTime _invoicedtime;
        public DateTime InvoicedTime
        {
            get{ return _invoicedtime; }
            set{ _invoicedtime = value; }
        }        
		/// <summary>
		/// InvoicedOperator
        /// </summary>		
		private string _invoicedoperator;
        public string InvoicedOperator
        {
            get{ return _invoicedoperator; }
            set{ _invoicedoperator = value; }
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
		   
	}
}

