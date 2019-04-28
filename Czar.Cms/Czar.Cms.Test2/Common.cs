using Czar.Cms.Core.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using Czar.Cms.Core.Models;
using Microsoft.Extensions.Configuration;
using Czar.Cms.Core.CodeGenerator;


namespace Czar.Cms.Test2
{
    public class Common
    {
        /// <summary>
        /// 构造依赖注入容器，然后传入参数
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider BuildServiceForSqlServer()
        {
            var services = new ServiceCollection();

            services.Configure<CodeGenerateOption>(options =>
            {
                options.ConnectionString = "server=.;Uid=sa;Pwd=123456;DataBase=Czar.Cms;MultipleActiveResultSets=True;";//这个必须
                options.DbType = DatabaseType.SqlServer.ToString();//数据库类型是SqlServer,其他数据类型参照枚举DatabaseType//这个也必须
                options.Author = "xqp";//作者名称，随你，不写为空
                options.OutputPath = @"D:\git\Cms\Czar.Cms";//实体模型输出路径，为空则默认为当前程序运行的路径
                options.IRepositoryNamespace = "Czar.Cms.IRepository";
                options.IServicesNamespace= "Czar.Cms.IServices";
                options.RepositoryNamespace= "Czar.Cms.Repository.SqlServer";
                options.ServicesNamespace= "Czar.Cms.Services";
                options.ModelsNamespace = "Czar.Cms.Models";//实体命名空间
            });
            services.AddSingleton<CodeGenerator>();//注入Model代码生成器
            return services.BuildServiceProvider(); //构建服务提供程序

        }
    }
}
