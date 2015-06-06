using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//Vehicle
		public class Vehicle
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
		/// PlateNumber
        /// </summary>		
		private string _platenumber;
        public string PlateNumber
        {
            get{ return _platenumber; }
            set{ _platenumber = value; }
        }        
		/// <summary>
		/// Driver
        /// </summary>		
		private string _driver;
        public string Driver
        {
            get{ return _driver; }
            set{ _driver = value; }
        }        
		/// <summary>
		/// LinkTel
        /// </summary>		
		private string _linktel;
        public string LinkTel
        {
            get{ return _linktel; }
            set{ _linktel = value; }
        }        
		/// <summary>
		/// LinkAddress
        /// </summary>		
		private string _linkaddress;
        public string LinkAddress
        {
            get{ return _linkaddress; }
            set{ _linkaddress = value; }
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

