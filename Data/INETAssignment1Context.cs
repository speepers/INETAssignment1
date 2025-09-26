using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using INETAssignment1.Models;

namespace INETAssignment1.Data
{
    public class INETAssignment1Context : DbContext
    {
        public INETAssignment1Context (DbContextOptions<INETAssignment1Context> options)
            : base(options)
        {
        }

        public DbSet<INETAssignment1.Models.Concert> Concert { get; set; } = default!;
        public DbSet<INETAssignment1.Models.Band> Band { get; set; } = default!;
        public DbSet<INETAssignment1.Models.Genre> Genre { get; set; } = default!;
        public DbSet<INETAssignment1.Models.Location> Location { get; set; } = default!;
    }
}
