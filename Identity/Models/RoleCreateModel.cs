using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class RoleCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
