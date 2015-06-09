using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//StoreOutGoodsVehicle
		public class StoreOutGoodsVehicle
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
		/// VehicleId
        /// </summary>		
		private int _vehicleid;
        public int VehicleId
        {
            get{ return _vehicleid; }
            set{ _vehicleid = value; }
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
		   
	}
}

