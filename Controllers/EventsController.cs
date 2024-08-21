using Microsoft.AspNetCore.Mvc;
using MVCApp.Domain.Entities;
using MVCApp.Repository;

namespace MVCApp.Controllers
{

    public class EventsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("events/adduser")]
        public IActionResult Test(User user)
        {
            UsersJSONRepository.AddUser(user);
            System.Console.WriteLine("Ols");
            return RedirectToAction("Index");
        }

    }

}