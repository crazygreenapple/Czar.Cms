using System;
using Sample05.DataModel;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = "Data Source=127.0.0.1;User ID=sa;Password=123456;Initial Catalog=Czar.Cms;Pooling=true;Max Pool Size=100;";
            //test_insert(sql);
            //test_mult_insert(sql);
            //test_select_one(sql);
            test_select_content_with_comment(sql);
        }

        #region 测试添加删除修改
        /// <summary>
        /// 测试插入单条数据
        /// </summary>
        static void test_insert(string sql)
        {
            var content = new Content
            {
                title = "标题1",
                content = "内容1",

            };
            using (var conn = new SqlConnection(sql))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert：插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量插入两条数据
        /// </summary>
        static void test_mult_insert(string sql)
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                title = "批量插入标题1",
                content = "批量插入内容1",

            },
               new Content
            {
                title = "批量插入标题2",
                content = "批量插入内容2",

            },
        };

            using (var conn = new SqlConnection(sql))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试删除单条数据
        /// </summary>
        static void test_del(string sql)
        {
            var content = new Content
            {
                id = 2,

            };
            using (var conn = new SqlConnection(sql))
            {
                string sql_insert = @"DELETE FROM [Content]
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_del：删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量删除两条数据
        /// </summary>
        static void test_mult_del(string sql)
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=3,

            },
               new Content
            {
                id=4,

            },
        };

            using (var conn = new SqlConnection(sql))
            {
                string sql_insert = @"DELETE FROM [Content]
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_del：删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试修改单条数据
        /// </summary>
        static void test_update(string sql)
        {
            var content = new Content
            {
                id = 5,
                title = "标题5",
                content = "内容5",

            };
            using (var conn = new SqlConnection(sql))
            {
                string sql_insert = @"UPDATE  [Content]
SET         title = @title, [content] = @content, modify_time = GETDATE()
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_update：修改了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量修改多条数据
        /// </summary>
        static void test_mult_update(string sql)
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=6,
                title = "批量修改标题6",
                content = "批量修改内容6",

            },
               new Content
            {
                id =7,
                title = "批量修改标题7",
                content = "批量修改内容7",

            },
        };

            using (var conn = new SqlConnection(sql))
            {
                string sql_insert = @"UPDATE  [Content]
SET         title = @title, [content] = @content, modify_time = GETDATE()
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_update：修改了{result}条数据！");
            }
        }

        /// <summary>
        /// 查询单条指定的数据
        /// </summary>
        static void test_select_one(string sql)
        {
            using (var conn = new SqlConnection(sql))
            {
                string sql_insert = @"select * from [dbo].[content] where id=@id";
                var result = conn.QueryFirstOrDefault<Content>(sql_insert, new { id = 1});
                Console.WriteLine($"test_select_one：查到的数据为：");
            }
        }

        /// <summary>
        /// 查询多条指定的数据
        /// </summary>
        static void test_select_list(string sql)
        {
            using (var conn = new SqlConnection(sql))
            {
                string sql_insert = @"select * from [dbo].[content] where id in @ids";
                var result = conn.Query<Content>(sql_insert, new { ids = new int[] { 2,3 } });
                Console.WriteLine($"test_select_one：查到的数据为：");
            }
        }

        static void test_select_content_with_comment(string sql)
        {
            using (var conn = new SqlConnection(sql))
            {
                string sql_select = "select * from content where id=@id;select * from comment where content_id=@id";
                using (var result = conn.QueryMultiple(sql_select, new { id = 5 }))
                {
                    var content = result.ReadFirstOrDefault<ContentWithCommnet>();
                    content.comments = result.Read<Comment>();
                    Console.WriteLine($"test_select_content_with_comment:内容5的评论数量{content.comments.Count()}");
                }
            }
        }
        #endregion
    }
}
