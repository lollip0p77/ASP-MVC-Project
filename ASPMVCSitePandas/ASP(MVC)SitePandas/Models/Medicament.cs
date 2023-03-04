using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    [Serializable]
    public class JsonResponseViewModelMedicament
    {        //bool for working or not       
        public int ResponseCode { get; set; }
        //data return        
        public string ResponseMessage { get; set; } = string.Empty;
    }
    public partial class Medicament
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string Nom { get; set; } = null!;
        [StringLength(2000)]
        [Unicode(false)]
        public string Description { get; set; } = null!;
        [Column("EnfantID")]
        public int EnfantId { get; set; }

        [ForeignKey("EnfantId")]
        [InverseProperty("Medicaments")]
        public virtual Enfant? Enfant { get; set; } = null!;
    }
}
