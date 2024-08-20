using Microsoft.AspNetCore.Mvc;
using MVCApp.Domain.Entities;
using MVCApp.Repository;

namespace MVCApp.Controllers
{
    public class CrudController : Controller
    {
        public IActionResult Index()
        {
            var data = UsersJSONRepository.GetUsers();
            return View(data);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                // Asegúrate de que UserRepository está correctamente referenciado
                UserRepository.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            // Asegúrate de pasar el modelo a la vista para mostrar errores
            return View(nameof(AddUser), user);
            //return View();
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            UsersJSONRepository.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
