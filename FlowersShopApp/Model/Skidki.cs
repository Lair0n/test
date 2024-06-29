namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Skidki")]
    public partial class Skidki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_skidki { get; set; }

        public int id_akzii { get; set; }

        public int id_zvetov { get; set; }

        public virtual Akzii Akzii { get; set; }

        public virtual Zvety Zvety { get; set; }
    }
}
