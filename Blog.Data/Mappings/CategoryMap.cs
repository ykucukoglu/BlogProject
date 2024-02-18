using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("E8661E76-15BB-438D-A259-D5639FE02087"),
                Name = "Spor",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category
            {
                Id = Guid.Parse("5BE059BF-E1A0-4064-86A2-69C05E5A17FE"),
                Name = "Ekonomi",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
