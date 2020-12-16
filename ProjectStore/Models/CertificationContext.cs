using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.Models
{
    public class CertificationContext : DbContext
    {
        public CertificationContext(DbContextOptions<CertificationContext> options) : base(options)
        {

        }

        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Categorie> Categories { get; set; }
    }
}
