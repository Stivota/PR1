using System.ComponentModel.DataAnnotations;

namespace ProyectoGrupo.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "El correo electr�nico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo electr�nico no v�lido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contrase�a es obligatoria.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "La contrase�a debe tener al menos 6 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirma tu contrase�a.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contrase�as no coinciden.")]
        public required string ConfirmPassword { get; set; }
    }
}
