using System.ComponentModel.DataAnnotations;

namespace SISGERED.shared.Entities
{
    public class Ubicacion
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
        public String TipoUbicacion { get; set; } = null;

        public bool Activa { get; set; } = true;


        // R02: un conjunto tiene muchas ubicaciones
        public int ConjuntoResidencialId { get; set; }  
        public ConjuntoResidencial ConjuntoResidencial { get; set; } = null!;

        // R18 y R05: una ubicación tiene muchas revisiones y muchos reportes
        public ICollection<Revision> Revisiones { get; set; } = new List<Revision>();
        public ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
    }
}

