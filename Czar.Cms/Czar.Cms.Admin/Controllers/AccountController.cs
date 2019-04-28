using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Czar.Cms.Admin.Validation;
using Czar.Cms.Core.Help;
using Czar.Cms.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Czar.Cms.Core.Extensions;
using Czar.Cms.IServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Czar.Cms.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly string CaptchaCodeSessionName = "CaptchaCode";
        private readonly string ManagerSignInErrorTimes = "ManagerSignInErrorTimes";
        private readonly int MaxErrorTimes = 3;
        private readonly IManagerService _service;

        public AccountController(IManagerService service)
        {
            _service = service;
        }

        public IActionResult Index(string returnurl)
        {
            if (string.IsNullOrEmpty(returnurl))
            {
                returnurl = "/";
            }
            ViewData["returnurl"] = returnurl;
            return View();
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public IActionResult GetCaptchaImage()
        {
            //生成验证码
            string captchaCode = CaptchaHelper.GenerateCaptchaCode();
            var result = new CaptchaResult();
            try
            {
                //生成图片
                 result = CaptchaHelper.GetImage(116, 36, captchaCode);
            }
            catch (Exception e)
            {

                throw;
            }
            //放入session
            HttpContext.Session.SetString(CaptchaCodeSessionName, captchaCode);
            //返回图片
            return new FileStreamResult(new MemoryStream(result.CaptchaByteData), "image/png");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken, Route("Account/SignIn")]
        public async Task<string> SignInAsync(LoginModel model)
        {
            try
            {
                BaseResult result = new BaseResult();
                #region 判断验证码
                if (!ValidateCaptchaCode(model.CaptchaCode))
                {
                    result.ResultCode = ResultCodeAddMsgKeys.SignInCaptchaCodeErrorCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.SignInCaptchaCodeErrorMsg;
                    return JsonHelper.ObjectToJSON(result);
                }
                #endregion
                #region 判断错误次数
                var ErrorTimes = HttpContext.Session.GetInt32(ManagerSignInErrorTimes);
                if (ErrorTimes == null)
                {
                    HttpContext.Session.SetInt32(ManagerSignInErrorTimes, 1);
                    ErrorTimes = 1;
                }
                else
                {
                    HttpContext.Session.SetInt32(ManagerSignInErrorTimes, ErrorTimes.Value + 1);
                }
                if (ErrorTimes > MaxErrorTimes)
                {
                    result.ResultCode = ResultCodeAddMsgKeys.SignInErrorTimesOverTimesCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.SignInErrorTimesOverTimesMsg;
                    return JsonHelper.ObjectToJSON(result);
                }
                #endregion
                #region 再次属性判断
                LoginModelValidation validation = new LoginModelValidation();
                ValidationResult results = validation.Validate(model);
                if (!results.IsValid)
                {
                    result.ResultCode = ResultCodeAddMsgKeys.CommonModelStateInvalidCode;
                    result.ResultMsg = results.ToString("||");
                }
                #endregion
                //获取IP
                model.Ip = HttpContext.GetClientUserIp();
                var manager = _service.SignIn(model);
                if (manager == null)
                {
                    result.ResultCode = ResultCodeAddMsgKeys.SignInPasswordOrUserNameErrorCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.SignInPasswordOrUserNameErrorMsg;
                }
                else if (manager.IsLock)
                {
                    result.ResultCode = ResultCodeAddMsgKeys.SignInUserLockedCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.SignInUserLockedMsg;
                }
                else
                {
                    var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.Name, manager.LoginName),
                    new Claim(ClaimTypes.MobilePhone, manager.Mobile),
                    new Claim(ClaimTypes.Role,manager.RoleID.ToString()),
                    new Claim("Id", manager.MID.ToString()),
                    new Claim("NickName",manager.UserName),
                    new Claim("Email", manager.Email),
                    new Claim("LoginCount",manager.LoginCount.ToString()),
                    new Claim("LoginLastIp",manager.LastLoginIP),
                    new Claim("LoginLastTime",manager.LastLoginTime?.ToString("yyyy-MM-dd HH:mm:ss")),
                };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                }
                return JsonHelper.ObjectToJSON(result);
            }
            catch (Exception e)
            {

                throw;
            }          
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [Route("Account/SignOut")]
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="userInputCaptcha"></param>
        /// <returns></returns>
        private bool ValidateCaptchaCode(string userInputCaptcha)
        {
            var isValid = userInputCaptcha.Equals(HttpContext.Session.GetString(CaptchaCodeSessionName), StringComparison.OrdinalIgnoreCase);
            HttpContext.Session.Remove(CaptchaCodeSessionName);
            return isValid;
        }
    }
}