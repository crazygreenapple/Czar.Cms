using Czar.Cms.Core.Models;
using Czar.Cms.Core.CodeGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace Czar.Cms.Test
{
    /// <summary>
    /// 代码生成
    /// </summary>
    [TestClass]
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
