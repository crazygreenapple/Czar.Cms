////////////////////////////////////////////////////////////////////
//                          _ooOoo_                               //
//                         o8888888o                              //
//                         88" . "88                              //
//                         (| ^_^ |)                              //
//                         O\  =  /O                              //
//                      ____/`---'\____                           //
//                    .'  \\|     |//  `.                         //
//                   /  \\|||  :  |||//  \                        //
//                  /  _||||| -:- |||||-  \                       //
//                  |   | \\\  -  /// |   |                       //
//                  | \_|  ''\---/''  |   |                       //
//                  \  .-\__  `-`  ___/-. /                       //
//                ___`. .'  /--.--\  `. . ___                     //
//              ."" '<  `.___\_<|>_/___.'  >'"".                  //
//            | | :  `- \`.;`\ _ /`;.`/ - ` : | |                 //
//            \  \ `-.   \_ __\ /__ _/   .-` /  /                 //
//      ========`-.____`-.___\_____/___.-`____.-'========         //
//                           `=---='                              //
//      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^        //
//                   佛祖保佑       永不宕机     永无BUG          //
////////////////////////////////////////////////////////////////////

/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：Manager后台管理员                                                    
*│　作    者：xqp                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-26 17:36:42                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：Manager                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czar.Cms.Models
{
	/// <summary>
	/// xqp
	/// 2019-03-26 17:36:42
	/// Manager后台管理员
	/// </summary>
	[Table("Manager")]
	public class Manager
	{
		/// <summary>
		/// 操作人ID
		/// </summary>
		[Key]
		public Int32 MID { get;set;}

		/// <summary>
		/// 用户名
		/// </summary>
		[MaxLength(12)]
		public String LoginName {get;set;}

		/// <summary>
		/// 密码
		/// </summary>
		[MaxLength(128)]
		public String Password {get;set;}

		/// <summary>
		/// 昵称
		/// </summary>
		[MaxLength(128)]
		public String UserName {get;set;}

		/// <summary>
		/// 头像
		/// </summary>
		[MaxLength(255)]
		public String HeadImg {get;set;}

		/// <summary>
		/// 手机号码
		/// </summary>
		[MaxLength(16)]
		public String Mobile {get;set;}

		/// <summary>
		/// 角色ID
		/// </summary>
		[MaxLength(10)]
		public Int32? RoleID {get;set;}

		/// <summary>
		/// 邮箱地址
		/// </summary>
		[MaxLength(16)]
		public String Email {get;set;}

		/// <summary>
		/// 登录次数
		/// </summary>
		[MaxLength(10)]
		public Int32? LoginCount {get;set;}

		/// <summary>
		/// 最后一次登录IP
		/// </summary>
		[MaxLength(64)]
		public String LastLoginIP {get;set;}

		/// <summary>
		/// 最后一次登录时间
		/// </summary>
		[MaxLength(23)]
		public DateTime? LastLoginTime {get;set;}

		/// <summary>
		/// 操作人
		/// </summary>
		[MaxLength(10)]
		public Int32? Opertor {get;set;}

		/// <summary>
		/// 添加时间
		/// </summary>
		[MaxLength(23)]
		public DateTime? UpdateTIME {get;set;}

		/// <summary>
		/// 是否删除
		/// </summary>
		[MaxLength(1)]
		public Boolean? IsDel {get;set;}

		/// <summary>
		/// 是否锁定
		/// </summary>
		[MaxLength(1)]
		public Boolean IsLock {get;set;}

		/// <summary>
		/// 备注
		/// </summary>
		[MaxLength(200)]
		public String Remark {get;set;}


	}
}
