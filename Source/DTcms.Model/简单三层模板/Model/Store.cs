using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
	 	//Store
		public class Store
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
		/// StoreDomainId
        /// </summary>		
		private int _storedomainid;
        public int StoreDomainId
        {
            get{ return _storedomainid; }
            set{ _storedomainid = value; }
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
		/// <summary>
		/// Manager
        /// </summary>		
		private string _manager;
        public string Manager
        {
            get{ return _manager; }
            set{ _manager = value; }
        }        
		/// <summary>
		/// Address
        /// </summary>		
		private string _address;
        public string Address
        {
            get{ return _address; }
            set{ _address = value; }
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

