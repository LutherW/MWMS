using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
	 	//StoreOutOrder
		public class StoreOutOrder
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
		/// CustomerId
        /// </summary>		
		private int _customerid;
        public int CustomerId
        {
            get{ return _customerid; }
            set{ _customerid = value; }
        }        
		/// <summary>
		/// StoreInUnitPriceStoreInOrderId
        /// </summary>		
		private int _storeinunitpricestoreinorderid;
        public int StoreInUnitPriceStoreInOrderId
        {
            get{ return _storeinunitpricestoreinorderid; }
            set{ _storeinunitpricestoreinorderid = value; }
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
		/// InvoiceMoney
        /// </summary>		
		private decimal _invoicemoney;
        public decimal InvoiceMoney
        {
            get{ return _invoicemoney; }
            set{ _invoicemoney = value; }
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
		/// Status
        /// </summary>		
		private int _status;
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
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

