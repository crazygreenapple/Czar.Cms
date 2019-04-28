using Czar.Cms.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Czar.Cms.Admin.Validation
{
    public class MenuValidation : AbstractValidator<MenuAddOrModifyModel>
    {
        public MenuValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Pid).NotNull().WithMessage("上级菜单不能为空");
            RuleFor(x => x.MenuName).NotEmpty().Length(0, 32).WithMessage("菜单别名不能为空且最大长度不能超过32个字符");
            RuleFor(x => x.ShowName).Length(0, 64).WithMessage("菜单显示名称长度不能超过64个字符");
            RuleFor(x => x.ImgUrl).Length(0, 128).WithMessage("菜单显示名称长度不能超过128个字符");
            RuleFor(x => x.LinkUrl).Length(0, 128).WithMessage("菜单显示名称长度不能超过128个字符");
        }
    }
}
