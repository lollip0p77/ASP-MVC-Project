using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    [Table("PersonnesAutoriser")]
    public partial class PersonnesAutoriser
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; } = null!;
        [StringLength(50)]
        public string Prenom { get; set; } = null!;
        [StringLength(14)]
        public string Telephone { get; set; } = null!;
        public bool ContactUrgence { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string LienEnfant { get; set; } = null!;
        [Column("EnfantID")]
        public int EnfantId { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("PersonnesAutoriser")]
        public virtual Enfant IdNavigation { get; set; } = null!;
    }
}
