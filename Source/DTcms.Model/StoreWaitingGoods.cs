using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//StoreWaitingGoods
		public class StoreWaitingGoods
	{
   		     
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
		/// Remark
        /// </summary>		
		private string _remark;
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>		
        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        /// <summary>
        /// 计划入库时间
        /// </summary>		
        private DateTime _storingTime;
        public DateTime StoringTime
        {
            get { return _storingTime; }
            set { _storingTime = value; }
        }

        /// <summary>
        /// 实际入库时间
        /// </summary>		
        private DateTime? _storedTime;
        public DateTime? StoredTime
        {
            get { return _storedTime; }
            set { _storedTime = value; }
        }

        /// <summary>
        /// 操作员
        /// </summary>		
        private string _admin;
        public string Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        /// <summary>
        /// 车辆
        /// </summary>
        private IList<StoreInGoodsVehicle> _goodsVehicle = new List<StoreInGoodsVehicle>();
        public IList<StoreInGoodsVehicle> GoodsVehicles
        {
            private set { _goodsVehicle = value; }
            get { return _goodsVehicle; }
        }

        public void AddGoodsVehicle(StoreInGoodsVehicle goodsVehicle)
        {
            _goodsVehicle.Add(goodsVehicle);
        }

        /// <summary>
        /// 附件
        /// </summary>
        private IList<Attach> _attachs = new List<Attach>();
        public IList<Attach> Attachs
        {
            private set { _attachs = value; }
            get { return _attachs; }
        }

        public void AddAttach(Attach attach)
        {
            _attachs.Add(attach);
        }
	}
}

