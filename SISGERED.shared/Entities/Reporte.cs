using SISGERED.API.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SISGERED.shared.Entities
{
    public class Reporte
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



        // R05: todo reporte tiene ubicación
        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; } = null!;

        // R03 y R04: lo crea un residente O un miembro del personal
        public int? ResidenteId { get; set; }
        public Residente? Residente { get; set; }

        public int? PersonalId { get; set; }
        public personal? Personal { get; set; }

        // R07: opcionalmente originado por una revisión
        public int? RevisionId { get; set; }
        public Revision? Revision { get; set; }

        // R06 y R10: puede no tener intervención
        public Intervecion? Intervecion { get; set; }
    }
}

