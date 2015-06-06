using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Model{
	 	//Customer
		public class Customer
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
		/// Code
        /// </summary>		
		private string _code;
        public string Code
        {
            get{ return _code; }
            set{ _code = value; }
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
		/// LinkMan
        /// </summary>		
		private string _linkman;
        public string LinkMan
        {
            get{ return _linkman; }
            set{ _linkman = value; }
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
		/// Email
        /// </summary>		
		private string _email;
        public string Email
        {
            get{ return _email; }
            set{ _email = value; }
        }        
		/// <summary>
		/// Fax
        /// </summary>		
		private string _fax;
        public string Fax
        {
            get{ return _fax; }
            set{ _fax = value; }
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
		   
	}
}

