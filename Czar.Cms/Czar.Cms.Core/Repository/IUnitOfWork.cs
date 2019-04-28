using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.Core.Repository
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 注册新增操作
        /// </summary>
        /// <param name="entity">实体</param>
        void Add<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// 注册更新操作
        /// </summary>
        /// <param name="entity">实体</param>
        void Update<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// 注册删除操作
        /// </summary>
        /// <param name="entity">实体</param>
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// 提交事务
        /// </summary>
        int Commit();
    }
}
