using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    public partial class Presence
    {
        [Key]
        [Column("EnfantID")]
        public int EnfantId { get; set; }
        [Key]
        [Column("EvenementID")]
        public int EvenementId { get; set; }
        public bool? Present { get; set; }

        [ForeignKey("EnfantId")]
        [InverseProperty("Presences")]
        public virtual Enfant Enfant { get; set; } = null!;
        [ForeignKey("EvenementId")]
        [InverseProperty("Presences")]
        public virtual Evenement Evenement { get; set; } = null!;
    }
}
