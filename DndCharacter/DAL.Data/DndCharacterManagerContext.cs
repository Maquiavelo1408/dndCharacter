using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore.SqlServer;
using DAL.Model.Entities;

namespace DAL.Data
{
    public partial class DndCharacterManagerContext : DbContext
    {
        public virtual DbSet<Character> Character { get; set; }

        public DndCharacterManagerContext(DbContextOptions<DndCharacterManagerContext> options) : base(options) { }
        public DndCharacterManagerContext() : base() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
        public class DndContextFactory
        {
            public DndCharacterManagerContext CreateDndContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<DndCharacterManagerContext>();
                var connectionString = "Server=localhost;Initial Catalog=DndCharacterManager;Persist Security Info=False;User ID=dnd;Password=dndSQL2018;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
                builder.UseSqlServer(connectionString,
                    b => { b.MigrationsAssembly("SL.API"); b.EnableRetryOnFailure(); });
                return new DndCharacterManagerContext(builder.Options);
            }
        }
    }
}
