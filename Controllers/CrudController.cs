using Microsoft.AspNetCore.Mvc;
using MVCApp.Domain.Entities;
using MVCApp.Repository;

namespace MVCApp.Controllers
{
    public class CrudController : Controller
    {
        [HttpGet("crud")]
        public IActionResult Index()
        {
            var data = UsersJSONRepository.GetUsers();
            return View(data);
        }

        [HttpGet("crud/adduser")]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost("crud/adduser")]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                // Asegúrate de que UserRepository está correctamente referenciado
                UsersJSONRepository.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            // Asegúrate de pasar el modelo a la vista para mostrar errores
            return View(nameof(AddUser), user);
            //return View();
        }

        [HttpPost("crud/deleteuser")]
        public IActionResult DeleteUser(int id)
        {
            UsersJSONRepository.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("crud/edituser")]
        public IActionResult EditUser(int userid){
            var user = UsersJSONRepository.GetUserByID(userid);
            return View(user);
        }

        [HttpPost("crud/edituser")]
        public IActionResult EditUser(User user){
            if(ModelState.IsValid){
                UsersJSONRepository.EditUser(user);
            }
            return View();
        }
    }
}
