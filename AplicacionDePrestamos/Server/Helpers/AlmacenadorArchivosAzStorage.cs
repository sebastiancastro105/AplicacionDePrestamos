using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionDePrestamos.Server.Helpers
{
    public class AlmacenadorArchivosAzStorage:IAlmacenadorArchivos
    {
        private string connctionString;
        public AlmacenadorArchivosAzStorage(IConfiguration configuration)
        {
            connctionString = "DefaultEndpointsProtocol=https;AccountName=blazorpagadiario;AccountKey=nlgL8dN+6XhP7VfGtEkwhWuD8EYM/ogztW58L17Czi2DuZWaHTIYxYxPRI3qAk/l/BjY41WUrQdRLmMw6w68NQ==;EndpointSuffix=core.windows.net";
        }
        public Task<string> EditarArchivo(byte[] contenido, string nombreContendor, string ruta)
        {
            throw new NotImplementedException();
        }

        public Task EliminarArchivos(string ruta, string nombreContendor)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GuardarArchivos(byte[] contenido, string extension, string nombreContendor)
        {
            var cliente = new BlobContainerClient(connctionString, nombreContendor);
            await cliente.CreateIfNotExistsAsync();
            cliente.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
            var archivoNombre = $"{Guid.NewGuid()}.{extension}";
            var blob = cliente.GetBlobClient(archivoNombre);

            using(var ms = new MemoryStream(contenido))
            {
                await blob.UploadAsync(ms);
            }

            return blob.Uri.ToString();
        }
    }
}
