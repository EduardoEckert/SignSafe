﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignSafe.Domain.Entities;
using SignSafe.Domain.Enums.Users;
using SignSafe.Domain.Extensions;

namespace SignSafe.Data.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Roles).IsRequired().HasDefaultValue(UserRoles.Standard.GetDescription());
        }
    }
}
