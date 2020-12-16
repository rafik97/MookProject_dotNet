using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string CategorieName { get; set; }
        public ICollection<Certification> Certifications { get; set; }
    }
}
