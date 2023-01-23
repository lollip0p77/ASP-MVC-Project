using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    public partial class Message
    {
        [Key]
        public int Id { get; set; }
        [Column("EducatriceID")]
        public int EducatriceId { get; set; }
        [Column("RepondantID")]
        public int RepondantId { get; set; }
        [Column("Message")]
        [StringLength(2000)]
        public string Message1 { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        public bool Statut { get; set; }
        public bool Actif { get; set; }

        [ForeignKey("EducatriceId")]
        [InverseProperty("Messages")]
        public virtual Educatrice Educatrice { get; set; } = null!;
        [ForeignKey("RepondantId")]
        [InverseProperty("Messages")]
        public virtual Repondant Repondant { get; set; } = null!;
    }
}
