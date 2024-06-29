namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Dostavka")]
    public partial class Dostavka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_dostavki { get; set; }

        public int id_klienta { get; set; }

        [Required]
        [StringLength(50)]
        public string adres_dostavki { get; set; }

        [Column(TypeName = "date")]
        public DateTime? data_dostavki { get; set; }

        public virtual Klienty Klienty { get; set; }
    }
}
