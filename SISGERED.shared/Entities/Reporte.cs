using System.ComponentModel.DataAnnotations;

namespace SISGERED.shared.Entities
{
    public class Reporte : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Titulo del reporte")]
        [Required(ErrorMessage = "El campo {0} es obligatorio"), MaxLength(100)]
        public string Titulo { get; set; } 

        [Display(Name = "Descripcion del reporte")]
        [Required(ErrorMessage = "El campo es obligatorio"), MaxLength(1000)]
        public string Descripcion { get; set; } 

        [Display(Name = "Fecha del reporte")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaReporte { get; set; } = DateTime.UtcNow;



      
        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; } = null!;

   
        public int? ResidenteId { get; set; }
        public Residente? Residente { get; set; }

        public int? PersonalId { get; set; }
        public personal? Personal { get; set; }

        
        public int? RevisionId { get; set; }
        public Revision? Revision { get; set; }

        
        public Intervension? Intervension { get; set; }

        
        public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
        {
            if ((ResidenteId.HasValue && PersonalId.HasValue) ||
                (!ResidenteId.HasValue && !PersonalId.HasValue))
            {
                yield return new ValidationResult(
                    "El reporte debe estar asociado a un residente o a un miembro del personal, pero no a ambos.",
                    new[] { nameof(ResidenteId), nameof(PersonalId) });
            }


        }
    }
}

