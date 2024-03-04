using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class AdminUserCreateModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Gender { get; set; }
    }
}
