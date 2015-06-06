using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model.DTcms.Model{
	 	//ReceivedUnitPrice
		public class ReceivedUnitPrice
	{
   		     
      	/// <summary>
		/// ReceivedMoneyId
        /// </summary>		
		private int _receivedmoneyid;
        public int ReceivedMoneyId
        {
            get{ return _receivedmoneyid; }
            set{ _receivedmoneyid = value; }
        }        
		/// <summary>
		/// BeginTime
        /// </summary>		
		private DateTime _begintime;
        public DateTime BeginTime
        {
            get{ return _begintime; }
            set{ _begintime = value; }
        }        
		/// <summary>
		/// Price
        /// </summary>		
		private decimal _price;
        public decimal Price
        {
            get{ return _price; }
            set{ _price = value; }
        }        
		/// <summary>
		/// EndTime
        /// </summary>		
		private DateTime _endtime;
        public DateTime EndTime
        {
            get{ return _endtime; }
            set{ _endtime = value; }
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

