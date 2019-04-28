using Czar.Cms.Core.CodeGenerator;
using Czar.Cms.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Czar.Cms.Test2
{
    public class GeneratorTest
    {
        /// <summary>
        /// 生成实体
        /// </summary>
        [Fact]
        public void GeneratorModelForSqlServer()
        {
            var serviceProvider = Common.BuildServiceForSqlServer();
            var codeGenerator = serviceProvider.GetRequiredService<CodeGenerator>();
            codeGenerator.GenerateTemplateCodesFromDatabase(true);
            Xunit.Assert.Equal("SQLServer", DatabaseType.SqlServer.ToString(), ignoreCase: true);

        }
    }
}
