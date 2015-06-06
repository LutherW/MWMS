using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//Attach
		public class Attach
	{
   		     
      	/// <summary>
		/// StoreInGoodsStoreInOrderId
        /// </summary>		
		private int _storeingoodsstoreinorderid;
        public int StoreInGoodsStoreInOrderId
        {
            get{ return _storeingoodsstoreinorderid; }
            set{ _storeingoodsstoreinorderid = value; }
        }        
		/// <summary>
		/// StoreInGoodsId
        /// </summary>		
		private int _storeingoodsid;
        public int StoreInGoodsId
        {
            get{ return _storeingoodsid; }
            set{ _storeingoodsid = value; }
        }        
		/// <summary>
		/// FilePath
        /// </summary>		
		private string _filepath;
        public string FilePath
        {
            get{ return _filepath; }
            set{ _filepath = value; }
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
		   
	}
}

