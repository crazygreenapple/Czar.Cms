using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czar.Cms.ViewModels
{
    public class MenuAddOrModifyModel
    {
        /// <summary>
		/// 主键
		/// </summary>
        public Int32 MenuID { get; set; }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        public Int32 Pid { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public String MenuName { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public String ShowName { get; set; }

        /// <summary>
        /// 图标地址
        /// </summary>
        public String ImgUrl { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public String LinkUrl { get; set; }

        /// <summary>
        /// 排序数字
        /// </summary>
        public Int32? OrderBy { get; set; }

        /// <summary>
        /// 操作权限（按钮权限时使用）
        /// </summary>
        public String OperPower { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public Int32? Opertor { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? UpdateTIME { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean? IsDel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }

    }
}
