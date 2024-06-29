namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Korzina")]
    public partial class Korzina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_korziny { get; set; }

        public int id_klienta { get; set; }

        public int id_zvetov { get; set; }

        public int kolichestvo { get; set; }

        public virtual Klienty Klienty { get; set; }

        public virtual Zvety Zvety { get; set; }
    }
}
