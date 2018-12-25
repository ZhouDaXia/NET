using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameWork
{

    public class EntityTest
    {

        public void Add()
        {
            using (var db = new BloggingContext())
            {
                var blog = new Blog() { Name = "test1" };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }

        public void Select()
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;
            }
        }

    }


    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.DisplayName).HasColumnName("display_name");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public virtual Blog blog { get; set; }


    }

    /*
     
        KeyAttribute  主键-支持组合键需要排序
        StringLengthAttribute
        MaxLengthAttribute  长度属性
        ConcurrencyCheckAttribute  要在进行并发检查
        RequiredAttribute  必填字段
        TimestampAttribute 时间戳并发
        ComplexTypeAttribute
        ColumnAttribute  列属性
        TableAttribute  表属性
        InversePropertyAttribute
        ForeignKeyAttribute  外键
        DatabaseGeneratedAttribute//标识
        NotMappedAttribute 非映射属性        
         */
    public class User
    {
        [Key]
        public string Username { get; set; }

        public string DisplayName { get; set; }
    }


}
