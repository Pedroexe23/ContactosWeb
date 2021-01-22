namespace Contacto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTACTOS
    {
        [Key]
        public int IDContacto { get; set; }

        [StringLength(25)]
        public string NOMBRE { get; set; }

        public int TELEFONO { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(30)]
        public string DIRECCION { get; set; }
    }
}
