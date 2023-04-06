using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCoreIdentityApp.Models;

namespace NetCoreIdentityApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login Model { get; set; } = null!;
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            if(ModelState.IsValid)
            {
               var IdentityResult= await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if (IdentityResult.Succeeded)
                {
                    if(returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }
                ModelState.AddModelError("","UserName or Password Incorrect");
            }
            return Page();
        }
    }
}
