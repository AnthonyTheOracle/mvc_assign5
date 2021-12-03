using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace mvc_assign5.Models
{
    public class SettlementContext : DbContext
    {
        public SettlementContext(DbContextOptions<SettlementContext> options)
            : base(options)
        {}
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<State> States { get; set; }
    }
}
