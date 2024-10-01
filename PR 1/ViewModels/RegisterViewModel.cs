using System.ComponentModel.DataAnnotations;

namespace ProyectoGrupo.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirma tu contraseña.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public required string ConfirmPassword { get; set; }
    }
}
