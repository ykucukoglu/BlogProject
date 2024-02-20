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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("621A6B12-5AE7-410C-8762-5A75C548078C"),
                RoleId = Guid.Parse("75F08B66-24E2-4235-B171-E25FD9DA4650")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("9D07D919-2662-44A7-BEF3-1E2D4C52CFCA"),
                RoleId = Guid.Parse("8A1CF120-7E01-4A16-BCF1-4D9E86E75F5D")
            });
        }
    }
}
