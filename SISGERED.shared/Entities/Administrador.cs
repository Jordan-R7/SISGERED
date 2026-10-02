using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SISGERED.shared.Entities
{
    public class Administrador
    {
        public int Id { get; set; }


        [Display(Name = "Número de cédula")]
        [MaxLength(10, ErrorMessage = "La cédula no puede tener más de 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Cedula { get; set; }


        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre debe tener solo letras")]
        public string Nombre { get; set; }


        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre debe tener solo letras")]
        public string Apellido { get; set; }


        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(10, ErrorMessage = "El teléfono no puede tener más de 10 caracteres")]
        public string Telefono { get; set; }


        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido")]
        public string Correo { get; set; }


      


        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
