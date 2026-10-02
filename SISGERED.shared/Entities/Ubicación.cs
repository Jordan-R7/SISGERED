using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;

namespace SISGERED.shared.Entities
{
    public class Ubicación
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la ubicación")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción de la ubicación")]
        [MaxLength(1000, ErrorMessage = "El campo no puede tener más de 200 caracteres.")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Descripcion {  get; set; }

        [Display(Name = "Tipo de ubicación (Porteria, Ascensor, Fachada, Zona Común, otro)")]
        [MaxLength(30, ErrorMessage = "El campo no puede tener más de 30 caracteres.")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public String TipoUbicacion{ get; set; }
       
    }
}
