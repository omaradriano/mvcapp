using Microsoft.AspNetCore.Mvc;
using MVCApp.Domain.Entities;
using MVCApp.Repository;

namespace MVCApp.Controllers
{

    public class PkmnController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Pkmn/Test")]
        public IActionResult Test(User user)
        {
            UsersJSONRepository.AddUser(user);
            System.Console.WriteLine("Ols");
            return RedirectToAction("Index");
        }

    }

}