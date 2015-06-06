using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
	 	//ReceivedOfStoreInGoods
		public class ReceivedOfStoreInGoods
	{
   		     
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
		   
	}
}

