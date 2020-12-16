using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.Models
{
    public class Certification
    {
        public int CertificationId { get; set; }

        [Required]
        public string CertificationName { get; set; }

        [Required]
        public string Description { get; set; }

        public int CategorieId { get; set; }

        public Categorie Categorie { get; set; }
    }
}
