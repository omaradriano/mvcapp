using System.ComponentModel.DataAnnotations;

namespace MVCApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")] 
        [StringLength(25, MinimumLength = 5)]
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Career {set;get;} = null!;
    }

}
