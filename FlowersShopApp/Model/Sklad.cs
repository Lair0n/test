namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Sklad")]
    public partial class Sklad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_sklada { get; set; }

        public int id_zvetov { get; set; }

        public int kolichestvo { get; set; }

        [Required]
        [StringLength(30)]
        public string adres { get; set; }

        public virtual Zvety Zvety { get; set; }
    }
}
