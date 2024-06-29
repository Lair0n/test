namespace FlowersShopApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Users")]
    public partial class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_usera { get; set; }

        [StringLength(20)]
        public string login { get; set; }

        [StringLength(20)]
        public string parol { get; set; }

        public int? id_sotrudnika { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }
    }
}
