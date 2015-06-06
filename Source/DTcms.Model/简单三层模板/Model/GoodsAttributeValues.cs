using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
	 	//GoodsAttributeValues
		public class GoodsAttributeValues
	{
   		     
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
		/// AttributeName
        /// </summary>		
		private string _attributename;
        public string AttributeName
        {
            get{ return _attributename; }
            set{ _attributename = value; }
        }        
		/// <summary>
		/// AttributeValue
        /// </summary>		
		private string _attributevalue;
        public string AttributeValue
        {
            get{ return _attributevalue; }
            set{ _attributevalue = value; }
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

