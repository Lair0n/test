namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Reiting_zvetov")]
    public partial class Reiting_zvetov
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_reitinga { get; set; }

        public int id_zvetov { get; set; }

        public decimal reiting { get; set; }

        public virtual Zvety Zvety { get; set; }
    }
}
