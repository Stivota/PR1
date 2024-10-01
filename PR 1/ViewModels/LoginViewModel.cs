using System.ComponentModel.DataAnnotations;
namespace ProyectoGrupo.Controllers
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contrase�a es obligatoria.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
