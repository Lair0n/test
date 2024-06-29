namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Prodaji")]
    public partial class Prodaji
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_prodaji { get; set; }

        public int id_zakaza { get; set; }

        public int id_sotrudnika { get; set; }

        [Column(TypeName = "date")]
        public DateTime data { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }

        public virtual Zakazy Zakazy { get; set; }
    }
}
