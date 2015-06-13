using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DTcms.Model
{
    //StoreOutGoodsVehicle
    public class StoreOutGoodsVehicle
    {
        public StoreOutGoodsVehicle() { }

        public StoreOutGoodsVehicle(int vehicleId, string remark, decimal count)
        {
            _vehicleid = vehicleId;
            _remark = remark;
            _count = count;
        }
        /// <summary>
        /// StoreOutGoodsId
        /// </summary>		
        private int _storeoutgoodswaitingid;
        public int StoreOutWaitingGoodsId
        {
            get { return _storeoutgoodswaitingid; }
            set { _storeoutgoodswaitingid = value; }
        }
        /// <summary>
        /// VehicleId
        /// </summary>		
        private int _vehicleid;
        public int VehicleId
        {
            get { return _vehicleid; }
            set { _vehicleid = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// Count
        /// </summary>		
        private decimal _count;
        public decimal Count
        {
            get { return _count; }
            set { _count = value; }
        }

    }
}

