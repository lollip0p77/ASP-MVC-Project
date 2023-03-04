using Microsoft.AspNetCore.Identity; // RoleManager, UserManager
using Microsoft.AspNetCore.Mvc; // Controller, IActionResult
using static System.Console;

namespace FR_W24_Exemple8_PRE2.Controllers;

public class RolesController : Controller
{
    private readonly string AdminRole = "Admin";
    private readonly string AdminUserName = "Admin";
    private readonly string AdminEmail = "Admin@test.com";
    private readonly string AdminPassword = "Adm!nW24";
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<IdentityUser> userManager;
    public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        if(!await roleManager.RoleExistsAsync(AdminRole))
        {
            await roleManager.CreateAsync(new IdentityRole(AdminRole));
        }
        IdentityUser user = await userManager.FindByEmailAsync(AdminEmail);
        if(user == null)
        {
            user = new();
            user.UserName = AdminUserName;
            user.Email = AdminEmail;

            IdentityResult result = await userManager.CreateAsync(user, AdminPassword);
            if (result.Succeeded)
            {
                WriteLine($"User {user.UserName} created successfully.");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    WriteLine(error.Description);
                }
            }
        }
        if (!user.EmailConfirmed)
        {
            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            IdentityResult result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                WriteLine($"User {user.UserName} email confirmed successfully.");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    WriteLine(error.Description);
                }
            }
        }
		if (!(await userManager.IsInRoleAsync(user, AdminRole)))
        {
            IdentityResult result = await userManager.AddToRoleAsync(user, AdminRole);
            if (result.Succeeded)
            {
                WriteLine($"User {user.UserName} added to {AdminRole} successfully.");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    WriteLine(error.Description);
                }
            }
        }
        return Redirect("/");
    }
}
