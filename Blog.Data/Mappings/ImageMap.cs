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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("C114004B-8D5B-4882-A5F4-909B5EA2F766"),
                FileName = "Image 1",
                FileType = "jpg",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Image
            {
                Id = Guid.Parse("E9C490B2-9834-4BAF-973B-003A3F938B74"),
                FileName = "Image 2",
                FileType = "jpg",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            }
            );
        }
    }
}
