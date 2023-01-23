using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    [Table("ListeDattente")]
    public partial class ListeDattente
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; } = null!;
        [StringLength(50)]
        public string Prenom { get; set; } = null!;
        [StringLength(14)]
        public string Telephone { get; set; } = null!;
        [StringLength(255)]
        public string Couriel { get; set; } = null!;
        public int NombreEnfants { get; set; }
        [StringLength(2000)]
        [Unicode(false)]
        public string Description { get; set; } = null!;
    }
}
