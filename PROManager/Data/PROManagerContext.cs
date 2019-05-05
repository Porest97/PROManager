using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROManager.Models;

namespace PROManager.Models
{
    public class PROManagerContext : DbContext
    {
        public PROManagerContext (DbContextOptions<PROManagerContext> options)
            : base(options)
        {
        }

        public DbSet<PROManager.Models.Person> Person { get; set; }

        public DbSet<PROManager.Models.RefereeCategory> RefereeCategory { get; set; }

        public DbSet<PROManager.Models.RefereeType> RefereeType { get; set; }

        public DbSet<PROManager.Models.RefereeDistrikt> RefereeDistrikt { get; set; }

        public DbSet<PROManager.Models.Match> Match { get; set; }

        public DbSet<PROManager.Models.AFAktivity> AFAktivity { get; set; }

        public DbSet<PROManager.Models.AFAktivityType> AFAktivityType { get; set; }
    }
}
