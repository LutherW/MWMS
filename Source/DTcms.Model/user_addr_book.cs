using System;
namespace DTcms.Model
{
	/// <summary>
	/// 收货地址簿
	/// </summary>
	[Serializable]
	public partial class user_addr_book
	{
		public user_addr_book()
		{}
		#region Model
		private int _id;
		private int _user_id;
		private string _user_name;
		private string _accept_name;
		private string _area;
		private string _address;
        private string _mobile = string.Empty;
        private string _telphone = string.Empty;
        private string _email = string.Empty;
        private string _post_code = string.Empty;
        private int _is_default = 0;
        private DateTime _add_time = DateTime.Now;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 收件人
		/// </summary>
		public string accept_name
		{
			set{ _accept_name=value;}
			get{return _accept_name;}
		}
		/// <summary>
		/// 省市区逗号分隔
		/// </summary>
		public string area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 手机号码
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 电话号码
		/// </summary>
		public string telphone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string post_code
		{
			set{ _post_code=value;}
			get{return _post_code;}
		}
		/// <summary>
		/// 是否默认
		/// </summary>
		public int is_default
		{
			set{ _is_default=value;}
			get{return _is_default;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

