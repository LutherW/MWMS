using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DTcms.Model
{
    //AllotOrder
    public class AllotOrder
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private DateTime _allotTime;
        public DateTime AllotTime
        {
            get { return _allotTime; }
            set { _allotTime = value; }
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
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// Admin
        /// </summary>		
        private string _admin;
        public string Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        /// <summary>
        /// Status
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// 调拨货物
        /// </summary>
        private IList<AllotGoods> _allotGoods = new List<AllotGoods>();
        public IList<AllotGoods> AllotGoods
        {
            private set { _allotGoods = value; }
            get { return _allotGoods; }
        }

        public void AddAllotGoods(AllotGoods allotGoods)
        {
            _allotGoods.Add(allotGoods);
        }
    }
}

