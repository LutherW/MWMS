using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//StoreInGoods
		public class StoreInGoods
	{
   		     
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
		/// Id
        /// </summary>		
		private int _id;
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// StoreId
        /// </summary>		
		private int _storeid;
        public int StoreId
        {
            get{ return _storeid; }
            set{ _storeid = value; }
        }        
		/// <summary>
		/// StoreModeId
        /// </summary>		
		private int _storemodeid;
        public int StoreModeId
        {
            get{ return _storemodeid; }
            set{ _storemodeid = value; }
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
		/// GoodsId
        /// </summary>		
		private int _goodsid;
        public int GoodsId
        {
            get{ return _goodsid; }
            set{ _goodsid = value; }
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
		/// Count
        /// </summary>		
		private decimal _count;
        public decimal Count
        {
            get{ return _count; }
            set{ _count = value; }
        }        
		/// <summary>
		/// StoredInTime
        /// </summary>		
		private DateTime _storedintime;
        public DateTime StoredInTime
        {
            get{ return _storedintime; }
            set{ _storedintime = value; }
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

