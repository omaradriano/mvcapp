using System.ComponentModel.DataAnnotations;

namespace MVCApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")] 
        [StringLength(25, MinimumLength = 5)]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Career {set;get;}
    }

}
