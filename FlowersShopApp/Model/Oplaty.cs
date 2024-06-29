namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Oplaty")]
    public partial class Oplaty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_oplaty { get; set; }

        public int id_zakaza { get; set; }

        public int id_tipa_oplaty { get; set; }

        [Column(TypeName = "date")]
        public DateTime data { get; set; }

        public virtual Tip_oplaty Tip_oplaty { get; set; }

        public virtual Zakazy Zakazy { get; set; }
    }
}
