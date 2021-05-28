using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionDePrestamos.Server.Helpers
{
    public interface IAlmacenadorArchivos
    {
        
        Task EliminarArchivos(string ruta, string nombreContendor);
        Task<string> EditarArchivo(byte[] contenido, string nombreContendor, string ruta);
        Task<string> GuardarArchivos(byte[] contenido, string extension, string nombreContendor);
    }
}
