using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VillageMVCWebApplication.Models
{
    public partial class VillageDataContex : DbContext
    {
        public VillageDataContex(string connectionString)
            : base("name=VillageDataContex")
        {
        }

        public virtual DbSet<Citizen> Citizens { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
