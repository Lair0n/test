namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Zakazy_klientov")]
    public partial class Zakazy_klientov
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_zakaza_klienta { get; set; }

        public int id_klienta { get; set; }

        public int id_zakaza { get; set; }

        public virtual Klienty Klienty { get; set; }

        public virtual Zakazy Zakazy { get; set; }
    }
}
