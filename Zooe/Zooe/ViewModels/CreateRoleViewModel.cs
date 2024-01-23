using System.ComponentModel.DataAnnotations;

namespace Zooe.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
        
    }
}