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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //builder.Property(x => x.Title).HasMaxLength(150);
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Deneme Makale 1",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 15,
                CategoryId = Guid.Parse("E8661E76-15BB-438D-A259-D5639FE02087"),
                ImageId = Guid.Parse("C114004B-8D5B-4882-A5F4-909B5EA2F766"),
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Deneme Makale 2",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 15,
                CategoryId = Guid.Parse("5BE059BF-E1A0-4064-86A2-69C05E5A17FE"),
                ImageId = Guid.Parse("E9C490B2-9834-4BAF-973B-003A3F938B74"),
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            }
            );
        }
    }
}
