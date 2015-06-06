using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
	 	//AllotOrder
		public class AllotOrder
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
		/// PurposeStoreId
        /// </summary>		
		private int _purposestoreid;
        public int PurposeStoreId
        {
            get{ return _purposestoreid; }
            set{ _purposestoreid = value; }
        }        
		/// <summary>
		/// SourceStoreId
        /// </summary>		
		private int _sourcestoreid;
        public int SourceStoreId
        {
            get{ return _sourcestoreid; }
            set{ _sourcestoreid = value; }
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
		   
	}
}

