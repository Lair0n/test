namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Postavki")]
    public partial class Postavki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_postavki { get; set; }

        public int id_postavschika { get; set; }

        public int id_zvetov { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_postavki { get; set; }

        public int kolichestvo { get; set; }

        public virtual Postavschiki Postavschiki { get; set; }

        public virtual Zvety Zvety { get; set; }
    }
}
