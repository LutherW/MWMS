using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DTcms.Model
{
    //StoreInGoodsVehicle
    public class StoreInGoodsVehicle
    {
        public StoreInGoodsVehicle() { }

        public StoreInGoodsVehicle(int vehicleId, string remark, decimal count)
        {
            _vehicleid = vehicleId;
            _remark = remark;
            _count = count;
        }

        /// <summary>
        /// StoreWaitingGoodsId
        /// </summary>		
        private int _storewaitinggoodsid;
        public int StoreWaitingGoodsId
        {
            get { return _storewaitinggoodsid; }
            set { _storewaitinggoodsid = value; }
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

