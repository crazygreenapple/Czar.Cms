using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Czar.Cms.Admin.Validation;
using Czar.Cms.Core.Help;
using Czar.Cms.IServices;
using Czar.Cms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using FluentValidation;

namespace Czar.Cms.Admin.Controllers
{
   public class ManagerController : BaseController
    {
        private readonly IManagerService _service;
        private readonly IManagerRoleService _roleService;
        public ManagerController(IManagerService service, IManagerRoleService roleService)
        {
            _service = service;
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string GetManagerList([FromQuery]ManagerRequestModel model)
        {
            return JsonHelper.ObjectToJSON(_service.GetManagerList(model));
        }

        [HttpGet]
        public IActionResult AddOrModify()
        {
            return View();
        }

        /// <summary>
        /// 添加或者编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string AddOrModify([FromForm]ManagerAddOrModifyModel item)
        {
            BaseResult result = new BaseResult();
            //验证
            ManagerValidation mvalidations = new ManagerValidation();
            ValidationResult results = mvalidations.Validate(item);
            if (results.IsValid)
            {
                result = _service.AddOrModify(item);
            }
            else
            {
                result.ResultCode = ResultCodeAddMsgKeys.CommonModelStateInvalidCode;
                result.ResultMsg = results.ToString("||");
            }
            var d = JsonHelper.ObjectToJSON(result);
            return d;
        }

        public IActionResult ChangePassword()
        {
            ViewData["NickName"] = User.Claims.FirstOrDefault(x => x.Type == "NickName")?.Value;
            ViewData["Id"] = User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string ChangePassword([FromForm]ChangePasswordModel item)
        {
            var result = new BaseResult();
            if (!ModelState.IsValid)
            {
                result.ResultCode = ResultCodeAddMsgKeys.CommonModelStateInvalidCode;
                result.ResultMsg = ToErrorString(ModelState, "||");
            }
            else
            {
                result = _service.ChangePassword(item);
            }
            return JsonHelper.ObjectToJSON(result);
        }
    }

    
}