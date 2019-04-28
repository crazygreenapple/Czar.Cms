using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czar.Cms.ViewModels
{
    public class ManagerAddOrModifyModel
    {
        /// <summary>
		/// 操作人ID
		/// </summary>
        public Int32 MID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public String LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public String HeadImg { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>

        public String Mobile { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public Int32 RoleID { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public Boolean IsLock { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }
    }
}
