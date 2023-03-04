using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    [Serializable]
    public class JsonResponseViewModel
    {        //bool for working or not       
        public int ResponseCode { get; set; }
        //data return        
        public string ResponseMessage { get; set; } = string.Empty;
    }
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
        [StringLength(5)]
        [Unicode(false)]
        public string ContactUrgence { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string LienEnfant { get; set; } = null!;
        [Column("EnfantID")]
        public int EnfantId { get; set; }

        [ForeignKey("EnfantId")]
        [InverseProperty("PersonnesAutorisers")]
        public virtual Enfant? Enfant { get; set; } = null!;
    }
}
