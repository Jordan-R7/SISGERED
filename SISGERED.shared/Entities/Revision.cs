using System.ComponentModel.DataAnnotations;

namespace SISGERED.shared.Entities
{
    public class Revision
    {
        public int Id { get; set; }


        [Display(Name = "Tipo de Revision")]
        [MaxLength(20, ErrorMessage = "El tipo de revision no puede tener más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String TipoRevision { get; set; }


        [Display(Name = "Estado de Revision")]
        [MaxLength(10, ErrorMessage = "El estado de revision no puede tener más de 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String EstadoRevision { get; set; }


        [Display(Name = "Fecha Programada")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaProgramada { get; set; }


        [Display(Name = "Fecha de Realizacion")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRealizacion { get; set; }


        [Display(Name = "Observaciones del reporte")]
        [MaxLength(1000, ErrorMessage = "Las observaciones no pueden tener más de 1000 caracteres")]
        public string? Observaciones { get; set; }


        // R17: una revisión pertenece a una única ubicación
        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; } = null!;

        // R19: realizada por un miembro del personal
        public int PersonalId { get; set; }
        public personal Personal { get; set; } = null!;

        // R22: opcionalmente verifica una intervención
        public int? IntervencionId { get; set; }
        public Intervencion? Intervension { get; set; }

        // R07 y R21: puede dar lugar a cero o varios reportes
        public ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();


    }
}
