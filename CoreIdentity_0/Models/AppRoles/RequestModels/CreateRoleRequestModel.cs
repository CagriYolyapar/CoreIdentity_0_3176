using System.ComponentModel.DataAnnotations;

namespace CoreIdentity_0.Models.AppRoles.RequestModels
{
    public class CreateRoleRequestModel
    {
        [Required(ErrorMessage = "{0} gereklidir")]
        [Display(Name = "Rol ismi")]
        public string RoleName { get; set; }
    }
}
