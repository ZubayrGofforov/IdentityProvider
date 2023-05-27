using Microsoft.AspNetCore.Mvc;
using SignInTechnologys.Common.Exceptions;
using SignInTechnologys.Dtos.Accounts;
using SignInTechnologys.Interfaces;

namespace SignInTechnologys.Controllers;
[Route("accounts")]

public class AccountsController : Controller
{
    private readonly IAccountService _accountService;
    public AccountsController(IAccountService accountService)
    {
        this._accountService = accountService;
    }

    [HttpGet("register")]
    public ViewResult Register() =>
        View("../Accounts/Register");

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(AccountRegisterDto accountRegisterDto)
    {
        if (ModelState.IsValid)
        {
            bool result = await _accountService.RegisterAsync(accountRegisterDto);
            if (result)
                return RedirectToAction("login", "accounts");
            else
                return Register();
        }
        return Register();
    }

    [HttpGet("login")]
    public ViewResult Login() => View("../Accounts/Login");

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                string token = await _accountService.LoginAsync(accountLoginDto);
                HttpContext.Response.Cookies.Append("X-Acces-Token", token, new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });

                return RedirectToAction("Index", "Home");
            }
            catch (ModelErrorException modelErrorException)
            {
                ModelState.AddModelError(modelErrorException.Property, modelErrorException.Message);
                return Login();
            }
            catch { return Login(); }
        }
        else return Login();
    }
}
