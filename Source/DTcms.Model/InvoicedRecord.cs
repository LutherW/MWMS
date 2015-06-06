using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//InvoicedRecord
		public class InvoicedRecord
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
		/// ReceivedMoneyId
        /// </summary>		
		private int _receivedmoneyid;
        public int ReceivedMoneyId
        {
            get{ return _receivedmoneyid; }
            set{ _receivedmoneyid = value; }
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
		/// Remark
        /// </summary>		
		private string _remark;
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
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
		/// Price
        /// </summary>		
		private decimal _price;
        public decimal Price
        {
            get{ return _price; }
            set{ _price = value; }
        }        
		   
	}
}

