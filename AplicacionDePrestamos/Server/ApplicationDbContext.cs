﻿using AplicacionDePrestamos.Shared.Entidates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionDePrestamos.Server
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

      
        public DbSet<Cliente> Clientes { get; set; }
    }
}
