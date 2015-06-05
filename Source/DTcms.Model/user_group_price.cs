﻿using System;
namespace DTcms.Model
{
    /// <summary>
    /// 会员组价格
    /// </summary>
    [Serializable]
    public partial class user_group_price
    {
        public user_group_price()
        { }
        #region Model
        private int _id;
        private int _article_id = 0;
        private int _goods_id = 0;
        private int _group_id = 0;
        private decimal _price = 0M;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 文章ID
        /// </summary>
        public int article_id
        {
            set { _article_id = value; }
            get { return _article_id; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int goods_id
        {
            set { _goods_id = value; }
            get { return _goods_id; }
        }
        /// <summary>
        /// 会员组ID
        /// </summary>
        public int group_id
        {
            set { _group_id = value; }
            get { return _group_id; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal price
        {
            set { _price = value; }
            get { return _price; }
        }
        #endregion Model

    }
}