using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.Models.Repositories
{
    public class CertificationRepository : ICertificationRepository
    {
        readonly CertificationContext context;
        public CertificationRepository(CertificationContext context)
        {
            this.context = context;
        }
        public void Add(Certification c)
        {
            context.Certifications.Add(c);
            context.SaveChanges();
        }

        public void Delete(Certification c)
        {
            Certification c1 = context.Certifications.Find(c.CertificationId);
            if (c1 != null)
            {
                context.Certifications.Remove(c1);
                context.SaveChanges();
            }
        }

        public void Edit(Certification c)
        {
            Certification oldCertification = context.Certifications.Find(c.CertificationId);
            if (oldCertification != null)
            {
                oldCertification.CertificationName = c.CertificationName;
                oldCertification.Description = c.Description;
                oldCertification.CategorieId = c.CategorieId;
                context.SaveChanges();
            }
        }

        public IList<Certification> FindByName(string name)
        {
            return context.Certifications.OrderBy(x => x.CertificationName).Include(x => x.Categorie).ToList();
        }

        public IList<Certification> GetAll()
        {
            return context.Certifications.OrderBy(x => x.CertificationName).Include(x => x.Categorie).ToList();
        }

        public Certification GetById(int id)
        {
            return context.Certifications.Where(x => x.CertificationId == id).Include(x => x.Categorie).SingleOrDefault();
        }

        public IList<Certification> GetCertificationsByCategorieID(int? categorieId)
        {
            return context.Certifications.Where(c => c.CertificationId.Equals(categorieId))
                .OrderBy(c => c.CertificationName)
                .Include(cert => cert.Categorie).ToList();
        }
    }
}
