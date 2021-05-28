using AplicacionDePrestamos.Server.Helpers;
using AplicacionDePrestamos.Shared.Entidates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionDePrestamos.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IAlmacenadorArchivos almacenadorArchivos;

        public ClientesController(ApplicationDbContext context , IAlmacenadorArchivos _almacenadorArchivos)
        {
            this.context = context;
            this.almacenadorArchivos = _almacenadorArchivos;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            if (!String.IsNullOrEmpty(cliente.Foto))
            {
                var fotoPersona = Convert.FromBase64String(cliente.Foto);
                cliente.Foto = await almacenadorArchivos.GuardarArchivos(fotoPersona, "png", "clientes");
            }
            context.Add(cliente);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {

            return await context.Clientes.ToListAsync();
        }
    }
}
