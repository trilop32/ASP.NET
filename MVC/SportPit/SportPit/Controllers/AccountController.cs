using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportPit.Data;
using SportPit.Models;

namespace SportPit.Controllers;

public class AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext context) : Controller
{
    public IActionResult Login()
    {
        var response = new LoginViewModel();

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(loginViewModel);
        }

        var user = await userManager.FindByEmailAsync(loginViewModel.EmailAddress);

        if (user != null)
        {
            //User is found, check password
            var passwordCheck = await userManager.CheckPasswordAsync(user, loginViewModel.Password);

            if (passwordCheck)
            {
                //Password correct, sign in
                var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            //Password is incorrect

            TempData["Error"] = "Wrong credential. Please, try again";

            return View(loginViewModel);
        }

        //User not found
        TempData["Error"] = "Wrong credential. Please try again";

        return View(loginViewModel);
    }

    public IActionResult Register()
    {
        var registerViewModel = new RegisterViewModel();

        return View(registerViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(registerViewModel);
        }

        var user = await userManager.FindByEmailAsync(registerViewModel.EmailAddress);

        if (user != null)
        {
            TempData["Error"] = "This email address is already in use";
            return View(registerViewModel);
        }

        var newUser = new User()
        {
            Email = registerViewModel.EmailAddress,
            UserName = registerViewModel.EmailAddress
        };

        var newUserResponse = await userManager.CreateAsync(newUser, registerViewModel.Password);

        if (newUserResponse.Succeeded)
        {
            await userManager.AddToRoleAsync(newUser, UserRoles.User);

            return RedirectToAction("Index", "Home");
        }
        else
        {
            TempData["Error"] = "Ошибка регистрации";

            return View(registerViewModel);
        }
    }


    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}
