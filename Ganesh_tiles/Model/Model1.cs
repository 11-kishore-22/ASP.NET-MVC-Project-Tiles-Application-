using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Ganesh_tiles.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tbl_Admin> tbl_Admin { get; set; }
        public virtual DbSet<tbl_Contact> tbl_Contact { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Admin>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Contact>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Contact>()
                .Property(e => e.Message)
                .IsUnicode(false);

           
        }
    }
}
