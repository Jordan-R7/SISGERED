using System;
using System.Collections.Generic;
using System.Text;

namespace SISGERED.shared.Entities
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int ConjuntoResidencialId { get; set; }
    }
}
