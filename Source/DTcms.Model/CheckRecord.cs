using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//CheckRecord
		public class CheckRecord
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
		/// VehicleId
        /// </summary>		
		private int _vehicleid;
        public int VehicleId
        {
            get{ return _vehicleid; }
            set{ _vehicleid = value; }
        }        
		/// <summary>
		/// CustomerId
        /// </summary>		
		private int _customerid;
        public int CustomerId
        {
            get{ return _customerid; }
            set{ _customerid = value; }
        }        
		/// <summary>
		/// HandlingModeId
        /// </summary>		
		private int _handlingmodeid;
        public int HandlingModeId
        {
            get{ return _handlingmodeid; }
            set{ _handlingmodeid = value; }
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
		/// InspectionNumber
        /// </summary>		
		private string _inspectionnumber;
        public string InspectionNumber
        {
            get{ return _inspectionnumber; }
            set{ _inspectionnumber = value; }
        }        
		/// <summary>
		/// CaseNumber
        /// </summary>		
		private string _casenumber;
        public string CaseNumber
        {
            get{ return _casenumber; }
            set{ _casenumber = value; }
        }        
		/// <summary>
		/// CheckResult
        /// </summary>		
		private string _checkresult;
        public string CheckResult
        {
            get{ return _checkresult; }
            set{ _checkresult = value; }
        }        
		/// <summary>
		/// RealName
        /// </summary>		
		private string _realname;
        public string RealName
        {
            get{ return _realname; }
            set{ _realname = value; }
        }        
		/// <summary>
		/// LinkMan
        /// </summary>		
		private string _linkman;
        public string LinkMan
        {
            get{ return _linkman; }
            set{ _linkman = value; }
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

