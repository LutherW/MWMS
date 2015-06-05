using System;
using System.Collections.Generic;

namespace DTcms.Model
{
    /// <summary>
    /// 商品价格
    /// </summary>
    [Serializable]
    public partial class article_goods
    {
        public article_goods()
        { }
        #region Model
        private int _id;
        private int _article_id;
        private string _goods_no;
        private string _spec_ids;
        private string _spec_text;
        private int _stock_quantity = 0;
        private decimal _market_price = 0M;
        private decimal _sell_price = 0M;
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
        /// 货号
        /// </summary>
        public string goods_no
        {
            set { _goods_no = value; }
            get { return _goods_no; }
        }
        /// <summary>
        /// 规格ID以逗号分隔开
        /// </summary>
        public string spec_ids
        {
            set { _spec_ids = value; }
            get { return _spec_ids; }
        }
        /// <summary>
        /// 规格描述
        /// </summary>
        public string spec_text
        {
            set { _spec_text = value; }
            get { return _spec_text; }
        }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int stock_quantity
        {
            set { _stock_quantity = value; }
            get { return _stock_quantity; }
        }
        /// <summary>
        /// 市场价格
        /// </summary>
        public decimal market_price
        {
            set { _market_price = value; }
            get { return _market_price; }
        }
        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal sell_price
        {
            set { _sell_price = value; }
            get { return _sell_price; }
        }

        private List<user_group_price> _group_prices;
        /// <summary>
        /// 会员组价格
        /// </summary>
        public List<user_group_price> group_prices
        {
            set { _group_prices = value; }
            get { return _group_prices; }
        }
        #endregion Model

    }
}