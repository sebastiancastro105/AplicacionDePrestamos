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

        public ClientesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
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
