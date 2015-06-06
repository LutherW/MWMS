using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
	 	//StoreOutUnitPrice
		public class StoreOutUnitPrice
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
		/// BeginTime
        /// </summary>		
		private DateTime _begintime;
        public DateTime BeginTime
        {
            get{ return _begintime; }
            set{ _begintime = value; }
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
		/// <summary>
		/// EndTime
        /// </summary>		
		private DateTime _endtime;
        public DateTime EndTime
        {
            get{ return _endtime; }
            set{ _endtime = value; }
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

