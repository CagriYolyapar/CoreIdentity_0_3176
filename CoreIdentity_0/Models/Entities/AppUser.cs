using CoreIdentity_0.Models.Enums;
using CoreIdentity_0.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CoreIdentity_0.Models.Entities
{
    public class AppUser : IdentityUser<int>,IEntity
    {
        public AppUser()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        //Relational Properties
        public virtual AppUserProfile AppUserProfile { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }


    }
}
