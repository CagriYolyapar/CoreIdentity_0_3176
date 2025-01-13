using CoreIdentity_0.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity_0.Models.Configurations
{
    public class AppRoleConfiguration : BaseConfiguration<AppRole>
    {
        

        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.UserRoles).WithOne( x => x.Role).HasForeignKey(x => x.RoleId).IsRequired();
        }
    }
}
