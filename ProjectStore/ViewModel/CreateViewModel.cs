using Microsoft.AspNetCore.Http;
using ProjectStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.ViewModel
{
    public class CreateViewModel
    {
        public int CertificationId { get; set; }

        [Required]
        public string CertificationName { get; set; }

        [Required]
        public string Description { get; set; }

        public int Price { get; set; }

        public IFormFile Photo { get; set; }
        public int CategorieId { get; set; }

        public Categorie Categorie { get; set; }


    }
}
