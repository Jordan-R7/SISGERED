namespace SISGERED.API.entidades
{
    public class intervecion
    {
        public int ID { get; set; }
        public int ID_personal { get; set; }

        public int ID_empresaexterna { get; set; }
        public int ID_reporte { get; set; }

        public int ID_Administrador { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechafin { get; set; }
        public string ID_administrador { get; set; }
        public DateOnly fechaProgramada { get; set; }
        public string Estado { get; set; }
        public string Prioridad { get; set; }


    }
}
