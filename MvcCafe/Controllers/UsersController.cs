using Microsoft.AspNetCore.Mvc;
using MvcCafe.Data;
using MvcCafe.Models;
using System.Security.Cryptography;
using System.Text;

namespace MvcCafe.Controllers
{
    public class UsersController : Controller
    {
        private readonly MvcCafeContext _context;

        public UsersController(MvcCafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        public string AddUser(RegisterViewModel registerViewModel)
        {
            using var md5 = MD5.Create();
            var bytes = Encoding.ASCII.GetBytes(registerViewModel.Password);
            var hashedBytes = md5.ComputeHash(bytes);
            var hashedPassword = Convert.ToHexString(hashedBytes);
            _context.Users.Add(new User { Login = registerViewModel.Login, PasswordHash = hashedPassword });
            _context.SaveChanges();
            return $"Created user { registerViewModel.Login}, hash {hashedPassword}";
        }
    }
}
