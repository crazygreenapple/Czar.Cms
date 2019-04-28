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
*│　描    述：后台管理菜单                                                    
*│　作    者：xqp                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-03-26 17:36:45                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Czar.Cms.Services                                  
*│　类    名： ManagerMenuService                                    
*└──────────────────────────────────────────────────────────────┘
*/
using Czar.Cms.IRepository;
using Czar.Cms.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using Czar.Cms.Core;
using Czar.Cms.ViewModels;
using Czar.Cms.Core.Extensions;
using System.Linq;
using Czar.Cms.Models;
using AutoMapper;

namespace Czar.Cms.Services
{
    public class ManagerMenuService: IManagerMenuService
    {
        private readonly IManagerMenuRepository _repository;
        private readonly IMapper _mapper;

        public ManagerMenuService(IManagerMenuRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public TableDataModel GetManagerMenu(MenuRequestModel requestModel)
        {
            string conditions = "where IsDel=0 ";//未删除的
            if (!requestModel.Key.IsNullOrWhiteSpace())
            {
                conditions += $"and ShowName like '%@Key%'";
            }
            var model = new TableDataModel();
            try
            {
                 model = new TableDataModel()
                {
                    count = _repository.RecordCount(conditions),
                    data = _repository.GetListPaged(requestModel.Page, requestModel.Limit, conditions, "menuID desc", new
                    {
                        Key = requestModel.Key,
                    }).ToList()
                };
            }
            catch (Exception e)
            {

                throw;
            }
           
            return model;
        }

        public List<ManagerMenu> GetChildListByParentId(int pid)
        {
            string conditions = "where IsDel=0 ";//未删除的
            if (pid >= 0)
            {
                conditions += " and pid=@pid";
            }
            return _repository.GetList(conditions, new
            {
                pid = pid
            }).ToList();
        }

        public BaseResult AddOrModify(MenuAddOrModifyModel item)
        {
            var result = new BaseResult();
            ManagerMenu model=new ManagerMenu();
            if (item.MenuID == 0)//新增
            {
                try
                {
                    _mapper.Map(item, model);
                }
                catch (Exception e)
                {

                    throw ;
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
                model = _repository.Get(item.MenuID);
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

        public BooleanResult IsExistsName(MenuAddOrModifyModel item)
        {
            bool data = false;
            if (item.MenuID > 0)
            {
                data = _repository.IsExistsName(item.MenuName, item.MenuID);
            }
            else
            {
                data = _repository.IsExistsName(item.MenuName);

            }
            var result = new BooleanResult
            {
                Data = data,
            };
            return result;
        }

        public BaseResult DeleteIds(int[] Ids)
        {
            var result = new BaseResult();
            if (Ids.Count() == 0)
            {
                result.ResultCode = ResultCodeAddMsgKeys.CommonModelStateInvalidCode;
                result.ResultMsg = ResultCodeAddMsgKeys.CommonModelStateInvalidMsg;

            }
            else
            {
                var count = _repository.DeleteLogical(Ids);
                if (count > 0)
                {
                    //成功
                    result.ResultCode = ResultCodeAddMsgKeys.CommonObjectSuccessCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.CommonObjectSuccessMsg;
                }
                else
                {
                    //失败
                    result.ResultCode = ResultCodeAddMsgKeys.CommonExceptionCode;
                    result.ResultMsg = ResultCodeAddMsgKeys.CommonExceptionMsg;
                }


            }
            return result;
        }
    }
}