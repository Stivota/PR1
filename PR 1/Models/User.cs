using System.ComponentModel.DataAnnotations;

namespace ProyectoGrupo.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "El correo electr�nico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo electr�nico no v�lido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contrase�a es obligatoria.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Otros campos seg�n necesidad
    }
}
