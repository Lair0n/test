namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Klienty")]
    public partial class Klienty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klienty()
        {
            Dostavka = new HashSet<Dostavka>();
            Korzina = new HashSet<Korzina>();
            Otzivy = new HashSet<Otzivy>();
            Zakazy = new HashSet<Zakazy>();
            Zakazy_klientov = new HashSet<Zakazy_klientov>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_klienta { get; set; }

        [Required]
        [StringLength(30)]
        public string familiya { get; set; }

        [Required]
        [StringLength(30)]
        public string imya { get; set; }

        [StringLength(30)]
        public string otchestvo { get; set; }

        [Required]
        [StringLength(50)]
        public string adres { get; set; }

        [Required]
        [StringLength(11)]
        public string nomer_telefona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dostavka> Dostavka { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Korzina> Korzina { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otzivy> Otzivy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zakazy> Zakazy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zakazy_klientov> Zakazy_klientov { get; set; }
    }
}
