namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Otzivy")]
    public partial class Otzivy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_otziva { get; set; }

        public int id_klienta { get; set; }

        [Required]
        [StringLength(150)]
        public string text_otziva { get; set; }

        public virtual Klienty Klienty { get; set; }
    }
}
