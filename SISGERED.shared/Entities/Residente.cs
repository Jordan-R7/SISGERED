using System.ComponentModel.DataAnnotations;

namespace SISGERED.shared.Entities
{
    public class Residente
    {
        public int Id { get; set; }
        [Display(Name = "Número de cédula")]
        [MaxLength(10, ErrorMessage = "La cédula no puede tener más de 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "La cédula debe tener solo números")]
        public string Cedula { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre debe tener solo letras")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El apellido debe tener solo letras")]
        public string Apellido { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(10, ErrorMessage = "El teléfono no puede tener más de 10 caracteres")]
        [RegularExpression(@"^[0-9\s]+$", ErrorMessage = "El teléfono debe tener solo números")]
        public string Telefono { get; set; }

        [Display(Name = "Correo electrónico")]
        [MaxLength(50, ErrorMessage = "El correo electrónico no puede tener más de 50 caracteres")]
        public string Correo { get; set; }

        [Display(Name = "Apartamento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Apartamento { get; set; }

        [Display(Name = "Conjunto residencial")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ConjuntoResidencialId { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";


    }
}
