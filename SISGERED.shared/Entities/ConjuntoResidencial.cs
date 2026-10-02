using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SISGERED.shared.Entities
{
    public class ConjuntoResidencial
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del conjunto residencial")]
        [MaxLength(50, ErrorMessage = "El nombre del conjunto residencial no puede tener más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }
        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(10, ErrorMessage = "El teléfono no puede tener más de 10 caracteres")]
        public string telefono { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "La dirección no puede tener más de 100 caracteres")]
        public string direccion { get; set; }

        public int AdministradorId { get; set; }

        [JsonIgnore]
        public Administrador Administrador { get; set; }



    }
}
