namespace Contacto.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContactoModel : DbContext
    {
        public ContactoModel()
            : base("name=ContactoModel")
        {
        }

        public virtual DbSet<CONTACTOS> CONTACTOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
