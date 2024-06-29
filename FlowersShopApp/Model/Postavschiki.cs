namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Postavschiki")]
    public partial class Postavschiki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Postavschiki()
        {
            Postavki = new HashSet<Postavki>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_postavschika { get; set; }

        [Required]
        [StringLength(30)]
        public string naimenovanie { get; set; }

        [Required]
        [StringLength(50)]
        public string adres { get; set; }

        [Required]
        [StringLength(11)]
        public string nomer_telefona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Postavki> Postavki { get; set; }
    }
}
