using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreSmart
{
    /// <summary>
    /// Main方法，程序的入口方法
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)//调用下面的方法返回IWebHostBuilder
                .Build()//用上面返回的IWebHostBuilder创建一个IWebHost
                .Run();//运行上面创建的IWebHost对象从而运行我们的Web应用程序换句话说就是启动一个一直运行监听http请求的任务
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)//使用默认的配置信息来初始化一个新的IWebHostBuilder实例
                .UseStartup<Startup>();// 为Web Host指定了Startup类
    }
}
