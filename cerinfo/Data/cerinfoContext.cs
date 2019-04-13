using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cerinfo.Models
{
    public class cerinfoContext : DbContext
    {
        public cerinfoContext (DbContextOptions<cerinfoContext> options)
            : base(options)
        {
        }

        public DbSet<cerinfo.Models.usuario> usuario { get; set; }
    }
}
