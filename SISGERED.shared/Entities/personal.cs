using System.ComponentModel.DataAnnotations;

namespace SISGERED.shared.Entities
{
    public class personal
    {
        public int Id { get; set; }


        [Display(Name = "Cédula") ]
        [MaxLength(10, ErrorMessage = "La cédula no puede tener más de 10 dígitos")]
        [Required(ErrorMessage = "La cédula es obligatoria")]
        [RegularExpression(@"^\d{8,10}$", ErrorMessage = "La cédula debe contener solo números y debe tener entre 8 y 10 dígitos")]
        public string Cedula { get; set; }


        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }


        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }


        [Display(Name = "Correo Electrónico")]
        [MaxLength(100, ErrorMessage = "El correo electrónico no puede tener más de 100 caracteres")]
        public string Email { get; set; }


        [Display(Name = "Telefono o Celular")]
        [MaxLength(10, ErrorMessage = "El teléfono no puede tener más de 10 caracteres")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe contener solo números y debe tener 10 dígitos")]
        public string Telefono { get; set; }


        [Display(Name = "Cargo")]
        [MaxLength(50, ErrorMessage = "El cargo no puede tener más de 50 caracteres")]
        public string Cargo { get; set; }


        public string Nombre_Completo => $"{Nombre} {Apellido}";







    }
}
