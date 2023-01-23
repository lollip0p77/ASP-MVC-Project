using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    [Table("DocumentsParent")]
    public partial class DocumentsParent
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Nom { get; set; } = null!;
        [Column("RepondantID")]
        public int RepondantId { get; set; }
        [StringLength(450)]
        public string DocumentLien { get; set; } = null!;

        [ForeignKey("RepondantId")]
        [InverseProperty("DocumentsParents")]
        public virtual Repondant Repondant { get; set; } = null!;
    }
}
