using Czar.Cms.Core.Models;
using Czar.Cms.Core.CodeGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace Czar.Cms.Test
{
    /// <summary>
    /// ��������
    /// </summary>
    [TestClass]
    public class GeneratorTest
    {
        /// <summary>
        /// ����ʵ��
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
