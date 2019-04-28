using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Czar.Cms.Core.Extensions;

namespace Czar.Cms.Admin.Controllers
{
    public class BaseController : Controller
    {

        /// <summary>
        /// modelState信息输出
        /// </summary>
        /// <param name="modelState">验证状态</param>
        /// <param name="split">分隔符</param>
        /// <returns>tostring</returns>
        protected string ToErrorString(ModelStateDictionary modelState, string split)
        {
            if (split.IsNullOrEmpty())
            {
                split = "||";
            }
            StringBuilder errinfo = new StringBuilder();
            foreach (var s in ModelState.Values)
            {
                foreach (var p in s.Errors)
                {
                    errinfo.AppendFormat("{0}{1}", p.ErrorMessage, split);
                }
            }
            if (errinfo.Length > split.Length)
            {
                errinfo.Remove(errinfo.Length - 2, split.Length);
            }
            return errinfo.ToString();
        }
    }
}