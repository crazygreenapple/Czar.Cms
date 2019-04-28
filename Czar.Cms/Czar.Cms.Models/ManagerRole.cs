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
*│　描    述：ManagerRole                                                    
*│　作    者：xqp                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-26 17:36:45                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：ManagerRole                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czar.Cms.Models
{
	/// <summary>
	/// xqp
	/// 2019-03-26 17:36:45
	/// ManagerRole
	/// </summary>
	[Table("ManagerRole")]
	public class ManagerRole
	{
		/// <summary>
		/// 角色ID
		/// </summary>
		[Key]
		public Int32 Id {get;set;}

		/// <summary>
		/// 操作人ID
		/// </summary>
		[MaxLength(10)]
		public Int32? MID {get;set;}

		/// <summary>
		/// 角色类型
		/// </summary>
		[MaxLength(10)]
		public Int32? RoleType {get;set;}

		/// <summary>
		/// 角色名称
		/// </summary>
		[MaxLength(12)]
		public String RoleName {get;set;}

		/// <summary>
		/// 是否系统默认
		/// </summary>
		[MaxLength(1)]
		public Boolean? IsDefault {get;set;}

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
		/// 备注
		/// </summary>
		[MaxLength(200)]
		public String Remark {get;set;}


	}
}
