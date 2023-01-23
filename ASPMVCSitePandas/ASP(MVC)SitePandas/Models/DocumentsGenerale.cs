using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    public partial class DocumentsGenerale
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string Nom { get; set; } = null!;
        [StringLength(255)]
        public string DocumentLien { get; set; } = null!;
    }
}
