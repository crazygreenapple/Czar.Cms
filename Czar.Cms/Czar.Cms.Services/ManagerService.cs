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
*│　描    述：Manager后台管理员                                                    
*│　作    者：xqp                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-03-26 17:36:43                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Czar.Cms.Services                                  
*│　类    名： ManagerService                                    
*└──────────────────────────────────────────────────────────────┘
*/
using Czar.Cms.IRepository;
using Czar.Cms.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using Czar.Cms.Models;
using Czar.Cms.ViewModels;
using Czar.Cms.Core.Help;
using System.Linq;
using Czar.Cms.Core.Extensions;
using AutoMapper;

namespace Czar.Cms.Services
{
    public class ManagerService: IManagerService
    {
        private readonly IManagerRepository _repository;
        private readonly IMapper _mapper;

        public ManagerService(IManagerRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BaseResult AddOrModify(ManagerAddOrModifyModel item)
        {
            var result = new BaseResult();
            Manager model = new Manager();
            if (item.MID == 0)//新增
            {
                try
                {
                    _mapper.Map<ManagerAddOrModifyModel>(model);
                    _mapper.Map(item, model);
                }
                catch (Exception e)
                {

                    throw;
                }
                model.Opertor = 1;
                model.IsDel = false;
                model.UpdateTIME = DateTime.Now;
                if (_repository.Insert(model) > 0)
                {
                    result.ResultCode = ResultCodeAddMsgKeys.CommonObjectSuccessCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.CommonObjectSuccessMsg;
                }
                else
                {
                    result.ResultCode = ResultCodeAddMsgKeys.CommonExceptionCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.CommonExceptionMsg;
                }
            }
            else//编辑
            {
                model = _repository.Get(item.MID);
                if (model != null)
                {
                    _mapper.Map(item, model);
                    model.Opertor = 1;
                    model.UpdateTIME = DateTime.Now;
                    model.IsDel = false;
                    if (_repository.Update(model) > 0)
                    {
                        result.ResultCode = ResultCodeAddMsgKeys.CommonObjectSuccessCode;
                        result.ResultMsg = ResultCodeAddMsgKeys.CommonObjectSuccessMsg;
                    }
                    else
                    {
                        result.ResultCode = ResultCodeAddMsgKeys.CommonExceptionCode;
                        result.ResultMsg = ResultCodeAddMsgKeys.CommonExceptionMsg;
                    }
                }
                else
                {
                    result.ResultCode = ResultCodeAddMsgKeys.CommonFailNoDataCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.CommonFailNoDataMsg;
                }
            }
            return result;
        }

        public BaseResult ChangePassword(ChangePasswordModel item)
        {
            BaseResult result = new BaseResult();
            string oldpwd = _repository.GetPasswordById(item.Id);
            if (oldpwd == AESEncryptHelper.Encode(item.OldPassword, CzarCmsKeys.AesEncryptKeys))
            {
                var count = _repository.ChangePasswordById(item.Id,AESEncryptHelper.Encode(item.NewPassword,CzarCmsKeys.AesEncryptKeys));
                if (count > 0)
                {
                    result.ResultCode = ResultCodeAddMsgKeys.CommonObjectSuccessCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.CommonObjectSuccessMsg;
                }
                else
                {
                    result.ResultCode = ResultCodeAddMsgKeys.CommonExceptionCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.CommonExceptionMsg;
                }
            }
            else
            {
                result.ResultCode = ResultCodeAddMsgKeys.PasswordOldErrorCode;
                result.ResultMsg = ResultCodeAddMsgKeys.PasswordOldErrorMsg;
            }
            return result;
        }

        public TableDataModel GetManagerList(ManagerRequestModel item)
        {
            string conditions = "where IsDel=0 ";//未删除的
            if (!item.Key.IsNullOrWhiteSpace())
            {
                conditions += $"and (UserName like '%@Key%' or LoginName like '%@Key%')";
            }
            var model = new TableDataModel();
            try
            {
                model = new TableDataModel()
                {
                    count = _repository.RecordCount(conditions),
                    data = _repository.GetListPaged(item.Page, item.Limit, conditions, "MID asc", new
                    {
                        Key = item.Key,
                    }).ToList()
                };
            }
            catch (Exception e)
            {

                throw;
            }

            return model;
        }

        public Manager SignIn(LoginModel model)
        {
            //密码加密
            model.Password = AESEncryptHelper.Encode(model.Password.Trim(), CzarCmsKeys.AesEncryptKeys);
            model.UserName = model.UserName.Trim();
            string conditions = "where IsDel=0 ";//未删除的
            conditions += $"and (LoginName = @UserName or Mobile =@UserName or Email =@UserName) and Password=@Password";
            var manager = _repository.GetList(conditions, model).FirstOrDefault();
            if (manager != null)
            {
                manager.LastLoginIP = model.Ip;
                manager.LoginCount += 1;
                manager.LastLoginTime = DateTime.Now;
                _repository.Update(manager);
                //_managerLogRepository.Insert(new ManagerLog()
                //{
                //    ActionType = CzarCmsEnums.ActionEnum.SignIn.ToString(),
                //    AddManageId = manager.Id,
                //    AddManagerNickName = manager.UserName,
                //    AddTime = DateTime.Now,
                //    AddIp = model.Ip,
                //    Remark = "用户登录"
                //});
            }
            return manager;
        }
    }
}