using CoreIdentity_0.Models.Enums;
using CoreIdentity_0.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CoreIdentity_0.Models.Entities
{
    public class AppUserRole : IdentityUserRole<int>, IEntity
    {
        public AppUserRole()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }

      

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        //Relational Properties
        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }


    }
}
