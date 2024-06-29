namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Akzii")]
    public partial class Akzii
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Akzii()
        {
            Skidki = new HashSet<Skidki>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_akzii { get; set; }

        [Required]
        [StringLength(30)]
        public string nazvanie { get; set; }

        public int prozent { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_nachala { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_konza { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skidki> Skidki { get; set; }
    }
}
