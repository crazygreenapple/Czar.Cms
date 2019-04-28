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
*│　描    述：后台管理菜单                                                    
*│　作    者：xqp                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-26 17:36:43                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：ManagerMenu                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czar.Cms.Models
{
	/// <summary>
	/// xqp
	/// 2019-03-26 17:36:43
	/// 后台管理菜单
	/// </summary>
	[Table("ManagerMenu")]
	public class ManagerMenu
	{
		/// <summary>
		/// 菜单ID
		/// </summary>
		[Key]
		public Int32 MenuID { get;set;}

		/// <summary>
		/// 父菜单ID
		/// </summary>
		[MaxLength(10)]
		public Int32? PID {get;set;}

		/// <summary>
		/// 菜单名称
		/// </summary>
		[MaxLength(32)]
		public String MenuName {get;set;}

		/// <summary>
		/// 显示名称
		/// </summary>
		[MaxLength(128)]
		public String ShowName {get;set;}

		/// <summary>
		/// 图标地址
		/// </summary>
		[MaxLength(255)]
		public String ImgUrl {get;set;}

		/// <summary>
		/// 链接地址
		/// </summary>
		[MaxLength(128)]
		public String LinkUrl {get;set;}

		/// <summary>
		/// 排序字段
		/// </summary>
		[MaxLength(10)]
		public Int32? OrderBy {get;set;}

		/// <summary>
		/// 操作权限
		/// </summary>
		[MaxLength(128)]
		public String OperPower {get;set;}

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
