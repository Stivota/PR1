using Microsoft.AspNetCore.Mvc;
using ProyectoGrupo.Models;
using ProyectoGrupo.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ProyectoGrupo.Controllers
{
    public class AccountController : Controller
    {
        // Simulaci�n de una base de datos
        private static List<User> users = new List<User>();

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    // Crear los claims
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        // Configurar propiedades si es necesario
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Credenciales inv�lidas.");
            }

            return View(model);
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (users.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("Username", "El nombre de usuario ya est� en uso.");
                    return View(model);
                }

                if (users.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "El correo electr�nico ya est� registrado.");
                    return View(model);
                }

                var user = new User
                {
                    Id = users.Count + 1,
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password // Nota: En producci�n, siempre hashear las contrase�as
                };

                users.Add(user);

                return RedirectToAction("Login");
            }

            return View(model);
        }

        // GET: /Account/ForgotPassword
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = users.FirstOrDefault(u => u.Email == model.Email);
                if (user != null)
                {
                    // Aqu� se enviar�a un correo para recuperar la contrase�a
                    // Para este ejemplo, simplemente mostramos un mensaje
                    ViewBag.Message = "Se ha enviado un enlace para restablecer la contrase�a a su correo electr�nico.";
                    return View();
                }

                ModelState.AddModelError("Email", "El correo electr�nico no est� registrado.");
            }

            return View(model);
        }

        // GET: /Account/Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
