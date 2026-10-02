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

    }
}
