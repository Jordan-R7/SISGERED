using System.ComponentModel.DataAnnotations;

namespace SISGERED.API.entidades
{
    public class Empresaaeaxterna
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo debe tener letras")]
        public string Nombre { get; set; }
        [Display(Name = "Direccion")]
        [MaxLength(100, ErrorMessage = "La dirección no puede tener más de 100 caracteres")]
        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }
        [Display(Name = "Telefono")]
        [MaxLength(11, ErrorMessage = "El teléfono no puede tener más de 11 caracteres")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El teléfono solo debe tener números")]
        public int Telefono { get; set; }
        [Display(Name = "Pagina web")]
        [Required(ErrorMessage = "La página web es obligatoria")]
        [RegularExpression(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$", ErrorMessage = "La página web no es válida")]
        public string NET { get; set; }
        [Display(Name = "Correo")]
        [MaxLength(100, ErrorMessage = "El correo no puede tener más de 100 caracteres")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "El correo no es válido")]
        public string Email { get; set; }
    }
}
