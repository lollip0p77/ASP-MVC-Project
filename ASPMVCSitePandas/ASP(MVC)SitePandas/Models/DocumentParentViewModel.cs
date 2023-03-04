using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_SitePandas.Models
{
    public class DocumentsParentViewModel
    {
        public int DocId { get; set; }
        public string DocNom { get; set; }
        public int FkRepondant { get; set; }

        [Required(ErrorMessage = "Choisissez un document..")]
        public IFormFile DocFile { get; set; } = null!;
    }
}