using System.ComponentModel.DataAnnotations;

namespace SISGERED.API.entidades
{
    public class Empresaaeaxterna
    {
        public int ID { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo debe tener letras")]
        public string Nombre { get; set; }
        
        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public string NET { get; set; }
        public string Correo { get; set; }
    }
}
