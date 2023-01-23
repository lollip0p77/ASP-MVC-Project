using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    [Table("AllergiesEnfant")]
    public partial class AllergiesEnfant
    {
        [Key]
        public int Id { get; set; }
        [Column("EnfantID")]
        public int EnfantId { get; set; }
        [Column("AllergieID")]
        public int AllergieId { get; set; }
        [StringLength(2000)]
        [Unicode(false)]
        public string Intervention { get; set; } = null!;

        [ForeignKey("AllergieId")]
        [InverseProperty("AllergiesEnfants")]
        public virtual Allergy Allergie { get; set; } = null!;
        [ForeignKey("EnfantId")]
        [InverseProperty("AllergiesEnfants")]
        public virtual Enfant Enfant { get; set; } = null!;
    }
}
