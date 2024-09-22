using Microsoft.AspNetCore.Identity;

namespace goodbyecouchpotato.Utilities
{
    public static class RoleInitializer
    {
        public static async Task InitializeRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // 檢查並創建 Admin 角色
            string[] roleNames = { "Admin", "PermiGuard", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // 創建預設的管理員用戶（如需要）
            //var adminEmail = "leo555555@gmail.com";
            //var adminPassword = "@aA1234567890";
            //var adminUser = await userManager.FindByEmailAsync(adminEmail);

            //if (adminUser == null)
            //{
            //    var newAdmin = new IdentityUser
            //    {
            //        UserName = adminEmail,
            //        Email = adminEmail,
            //        EmailConfirmed = true
            //    };

            //    var createAdmin = await userManager.CreateAsync(newAdmin, adminPassword);
            //    if (createAdmin.Succeeded)
            //    {
            //        await userManager.AddToRoleAsync(newAdmin, "Admin");
            //    }
            //}
        }
    }
}
