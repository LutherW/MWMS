using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//StoreOutGoodsWithVehicles
		public class StoreOutGoodsWithVehicles
	{
   		     
      	/// <summary>
		/// StoreOutGoodsStoreOutOrderId
        /// </summary>		
		private int _storeoutgoodsstoreoutorderid;
        public int StoreOutGoodsStoreOutOrderId
        {
            get{ return _storeoutgoodsstoreoutorderid; }
            set{ _storeoutgoodsstoreoutorderid = value; }
        }        
		/// <summary>
		/// StoreOutGoodsId
        /// </summary>		
		private int _storeoutgoodsid;
        public int StoreOutGoodsId
        {
            get{ return _storeoutgoodsid; }
            set{ _storeoutgoodsid = value; }
        }        
		/// <summary>
		/// StoreOutGoodsVehicleId
        /// </summary>		
		private int _storeoutgoodsvehicleid;
        public int StoreOutGoodsVehicleId
        {
            get{ return _storeoutgoodsvehicleid; }
            set{ _storeoutgoodsvehicleid = value; }
        }        
		   
	}
}

