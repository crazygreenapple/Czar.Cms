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
*│　描    述：操作日志                                                    
*│　作    者：xqp                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-26 17:36:46                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：OperLog                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czar.Cms.Models
{
	/// <summary>
	/// xqp
	/// 2019-03-26 17:36:46
	/// 操作日志
	/// </summary>
	[Table("OperLog")]
	public class OperLog
	{
		/// <summary>
		/// 主键
		/// </summary>
		[Key]
		public Int32 Id {get;set;}

		/// <summary>
		/// Man_操作人ID
		/// </summary>
		[MaxLength(10)]
		public Int32? Man_MID {get;set;}

		/// <summary>
		/// 操作类型
		/// </summary>
		[MaxLength(128)]
		public String OperType {get;set;}

		/// <summary>
		/// 操作人ID
		/// </summary>
		[MaxLength(10)]
		public Int32? MID {get;set;}

		/// <summary>
		/// 操作人
		/// </summary>
		[MaxLength(10)]
		public Int32? Opertor {get;set;}

		/// <summary>
		/// 操作时间
		/// </summary>
		[MaxLength(23)]
		public DateTime? OperTime {get;set;}

		/// <summary>
		/// 操作IP
		/// </summary>
		[MaxLength(12)]
		public String OperIP {get;set;}

		/// <summary>
		/// 操作人名称
		/// </summary>
		[MaxLength(12)]
		public String OpertorName {get;set;}

		/// <summary>
		/// 备注
		/// </summary>
		[MaxLength(200)]
		public String Remark {get;set;}


	}
}
