using System.ComponentModel.DataAnnotations;

namespace SISGERED.shared.Entities
{
    public class Intervension : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Personal")]
        public int? ID_personal { get; set; }


        [Display(Name = "Empresa Externa")]
        public int? ID_Empresaexterna { get; set; }


        [Display(Name = "Reporte")]
        [Required(ErrorMessage = "El ID del reporte es obligatorio")]
        public int ID_Reporte { get; set; }
        public Reporte Reporte { get; set; }

        [Display(Name = "Administrador")]
        [Required(ErrorMessage = "El ID del administrador es obligatorio")]
        public int ID_Administrador { get; set; }
        public Administrador Administrador { get; set; }


        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateTime Fechainicio { get; set; }


        [Display(Name = "Fecha de Fin")]
        [Required(ErrorMessage = "La fecha final es obligatoria")]
        public DateTime Fechafin { get; set; }


        [Display(Name = "Fecha Programada")]
        [Required(ErrorMessage = "La fecha programada es obligatoria")]
        public DateOnly FechaProgramada { get; set; }


        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; }


        [Display(Name = "Prioridad")]
        [Required(ErrorMessage = "La prioridad es obligatoria")]
        public string Prioridad { get; set; }


        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (Fechafin <= Fechainicio)
            {
                yield return new ValidationResult(
                "La fecha de fin debe ser mayor que la fecha de inicio",
                [nameof(Fechafin)]);
            }

            if (FechaProgramada < DateOnly.FromDateTime(DateTime.Today))
            {
                yield return new ValidationResult(
                "La fecha programada no puede ser menor que la fecha actual",
                [nameof(FechaProgramada)]);
            }
        }

        

    }
}
