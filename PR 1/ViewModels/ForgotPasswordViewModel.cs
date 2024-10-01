using System.ComponentModel.DataAnnotations;

namespace ProyectoGrupo.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "El correo electr�nico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo electr�nico no v�lido.")]
        public string Email { get; set; }
    }
}
