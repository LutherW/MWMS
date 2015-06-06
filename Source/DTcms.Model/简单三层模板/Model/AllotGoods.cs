using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
	 	//AllotGoods
		public class AllotGoods
	{
   		     
      	/// <summary>
		/// AllotOrderId
        /// </summary>		
		private int _allotorderid;
        public int AllotOrderId
        {
            get{ return _allotorderid; }
            set{ _allotorderid = value; }
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
		/// StoreInOrderId
        /// </summary>		
		private int _storeinorderid;
        public int StoreInOrderId
        {
            get{ return _storeinorderid; }
            set{ _storeinorderid = value; }
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
		/// Remark
        /// </summary>		
		private string _remark;
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
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

