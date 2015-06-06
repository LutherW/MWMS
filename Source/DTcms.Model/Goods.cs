using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//Goods
		public class Goods
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
		/// UnitId
        /// </summary>		
		private int _unitid;
        public int UnitId
        {
            get{ return _unitid; }
            set{ _unitid = value; }
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
		/// StoreModeId
        /// </summary>		
		private int _storemodeid;
        public int StoreModeId
        {
            get{ return _storemodeid; }
            set{ _storemodeid = value; }
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
		/// Name
        /// </summary>		
		private string _name;
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		   
	}
}

