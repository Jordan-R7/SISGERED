using SISGERED.shared.Entities;

namespace SISGERED.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedDbAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            // Sembramos solo los DATOS MAESTROS (Predecibles)
            await CheckAdministradoresAsync();
            await CheckConjuntosResidencialesAsync();
            await CheckUbicacionesAsync();
            await CheckPersonalAsync();
            await CheckEmpresasExternasAsync();

            // Las tablas Reportes, Revisiones e Intervenciones se dejan intactas (vacías) 
            // porque son transaccionales y se generarán en el día a día.
        }

        private async Task CheckAdministradoresAsync()
        {
            if (!_context.Administradores.Any())
            {
                _context.Administradores.Add(new Administrador
                {
                    Cedula = "1000100010",
                    Nombre = "Carlos",
                    Apellido = "Pérez",
                    Telefono = "3001234567",
                    Correo = "admin@sisgered.com"
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckConjuntosResidencialesAsync()
        {
            if (!_context.ConjuntosResidenciales.Any())
            {
                var admin = _context.Administradores.FirstOrDefault(a => a.Cedula == "1000100010");
                if (admin != null)
                {
                    _context.ConjuntosResidenciales.Add(new ConjuntoResidencial
                    {
                        Nombre = "Conjunto Los Pinos",
                        Telefono = "6041234567",
                        Direccion = "Calle 123 # 45-67",
                        AdministradorId = admin.Id
                    });
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task CheckUbicacionesAsync()
        {
            if (!_context.Ubicaciones.Any())
            {
                var conjunto = _context.ConjuntosResidenciales.FirstOrDefault(c => c.Nombre == "Conjunto Los Pinos");
                if (conjunto != null)
                {
                    // Sembramos zonas comunes que siempre existen en un conjunto
                    _context.Ubicaciones.Add(new Ubicacion { Nombre = "Recepción", Descripcion = "Lobby principal", TipoUbicacion = "Zona Común", Activa = true, ConjuntoResidencialId = conjunto.Id });
                    _context.Ubicaciones.Add(new Ubicacion { Nombre = "Piscina", Descripcion = "Zona húmeda", TipoUbicacion = "Zona Húmeda", Activa = true, ConjuntoResidencialId = conjunto.Id });
                    _context.Ubicaciones.Add(new Ubicacion { Nombre = "Cuarto de Bombas", Descripcion = "Sala de máquinas de agua", TipoUbicacion = "Técnica", Activa = true, ConjuntoResidencialId = conjunto.Id });
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task CheckPersonalAsync()
        {
            if (!_context.Personal.Any())
            {
                _context.Personal.Add(new personal
                {
                    Cedula = "987654321",
                    Nombre = "Juan",
                    Apellido = "Mantenimiento",
                    Email = "juan@mantenimiento.com",
                    Telefono = "3012345671",
                    Cargo = "Técnico de reparaciones"
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckEmpresasExternasAsync()
        {
            if (!_context.EmpresasExternas.Any())
            {
                _context.EmpresasExternas.Add(new EmpresaExterna
                {
                    Nombre = "Ascensores Colombia SA",
                    Direccion = "Carrera 45 # 10-20",
                    Telefono = "3102565897",
                    NIT = "9001234567",
                    Email = "soporte@ascensores.com"
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}