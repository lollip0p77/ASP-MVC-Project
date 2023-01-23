using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    [Table("MedicamentTransition")]
    public partial class MedicamentTransition
    {
        [Key]
        public int Id { get; set; }
        [Column("EnfantID")]
        public int EnfantId { get; set; }
        [Column("MedicamentsEnfantsID")]
        public int MedicamentsEnfantsId { get; set; }

        [ForeignKey("EnfantId")]
        [InverseProperty("MedicamentTransitions")]
        public virtual Enfant Enfant { get; set; } = null!;
        [ForeignKey("MedicamentsEnfantsId")]
        [InverseProperty("MedicamentTransitions")]
        public virtual Medicament MedicamentsEnfants { get; set; } = null!;
    }
}
