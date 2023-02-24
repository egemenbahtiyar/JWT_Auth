using JWT_Auth_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWT_Auth_Data.Configurations;

internal class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
{
    public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.Code).IsRequired().HasMaxLength(200);
    }
}