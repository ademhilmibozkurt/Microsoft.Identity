using System.Reflection.Metadata;

namespace Identity.Models
{
    public class RoleAssignModel
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

        public bool IsExist { get; set; }
    }

    public class RoleAssignSendModel
    {
        public int UserId { get; set; }

        public List<RoleAssignModel> Roles { get; set; }
    }
}
