using Czar.Cms.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Czar.Cms.Admin.Validation
{
    public class ManagerValidation : AbstractValidator<ManagerAddOrModifyModel>
    {
        public ManagerValidation()
        {
            CascadeMode= CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.UserName).NotEmpty().WithMessage("用户名不能为空！");
            RuleFor(x => x.LoginName).NotEmpty().WithMessage("登录名不能为空！");
            RuleFor(x => x.RoleID).NotNull().WithMessage("角色ID不能不选！");
            RuleFor(x => x.Email).NotEmpty().WithMessage("邮箱不能为空！");
        }
    }
}
