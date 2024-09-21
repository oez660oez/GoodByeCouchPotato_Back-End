using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace goodbyecouchpotato.Areas.AdministratorManagement.Views
{
    public partial class AdminViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<RoleInfo> Roles { get; set; }

        public class RoleInfo
        {
            public string RoleId { get; set; }
            public string RoleName { get; set; }
        }
    }
}
