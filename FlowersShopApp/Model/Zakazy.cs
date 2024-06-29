namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Zakazy")]
    public partial class Zakazy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zakazy()
        {
            Oplaty = new HashSet<Oplaty>();
            Prodaji = new HashSet<Prodaji>();
            Zakazy_klientov = new HashSet<Zakazy_klientov>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_zakaza { get; set; }

        public int klient { get; set; }

        public int zvety { get; set; }

        public int kolichestvo { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_zakaza { get; set; }

        public virtual Klienty Klienty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oplaty> Oplaty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prodaji> Prodaji { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zakazy_klientov> Zakazy_klientov { get; set; }

        public virtual Zvety Zvety1 { get; set; }
    }
}
