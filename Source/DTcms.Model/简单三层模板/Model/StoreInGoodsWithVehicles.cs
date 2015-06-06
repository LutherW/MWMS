using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
	 	//StoreInGoodsWithVehicles
		public class StoreInGoodsWithVehicles
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
		/// StoreInGoodsVehicleId
        /// </summary>		
		private int _storeingoodsvehicleid;
        public int StoreInGoodsVehicleId
        {
            get{ return _storeingoodsvehicleid; }
            set{ _storeingoodsvehicleid = value; }
        }        
		   
	}
}

