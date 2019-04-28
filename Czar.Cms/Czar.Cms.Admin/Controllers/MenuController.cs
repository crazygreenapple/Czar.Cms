using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Czar.Cms.IServices;
using Czar.Cms.Services;
using Czar.Cms.Core.Help;
using Czar.Cms.ViewModels;
using Czar.Cms.Admin.Validation;
using FluentValidation.Results;

namespace Czar.Cms.Admin.Controllers
{
    public class MenuController : Controller
    {
        private readonly IManagerMenuService menuService;
        public MenuController(IManagerMenuService service)
        {
            menuService = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetManagerMenu([FromQuery]MenuRequestModel model)
        {
           return JsonHelper.ObjectToJSON(menuService.GetManagerMenu(model));
        }


        [HttpGet]
        public IActionResult AddOrModify()
        {
            return View(menuService.GetChildListByParentId(0));
        }

        /// <summary>
        /// 添加或者编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string AddOrModify([FromForm]MenuAddOrModifyModel item)
        {
            BaseResult result = new BaseResult();
            //验证
            MenuValidation mvalidations = new MenuValidation();
            ValidationResult results = mvalidations.Validate(item);
            if (results.IsValid)
            {
                result = menuService.AddOrModify(item);
            }
            else
            {
                result.ResultCode = ResultCodeAddMsgKeys.CommonModelStateInvalidCode;
                result.ResultMsg = results.ToString("||");
            }
            var d = JsonHelper.ObjectToJSON(result);
            return d;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Delete(int[] menuId)
        {
            return JsonHelper.ObjectToJSON(menuService.DeleteIds(menuId));
        }

        [HttpGet]
        public string IsExistsName(string name, int id)
        {
            MenuAddOrModifyModel item=new MenuAddOrModifyModel { MenuName=name,MenuID=id};
            var result = menuService.IsExistsName(item);
            var d= JsonHelper.ObjectToJSON(result);
            return d;
        }


        [HttpGet]
        public string LoadDataWithParentId([FromQuery]int ParentId = -1)
        {
            return JsonHelper.ObjectToJSON(menuService.GetChildListByParentId(ParentId));
        }
    }
}