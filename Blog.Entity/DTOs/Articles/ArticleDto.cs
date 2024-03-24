using Blog.Entity.DTOs.Categories;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.DTOs.Articles
{
    public class ArticleDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryDto Category { get; set; }
        public Image Image { get; set; }
        public string CreatedBy { get; set; }
        public  DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public UserDto User { get; set; }
        public int ViewCount { get; set; }

    }
}
