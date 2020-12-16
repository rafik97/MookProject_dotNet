using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.Models.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        readonly CertificationContext context;
        public CategorieRepository(CertificationContext context)
        {
            this.context = context;
        }

        public void Add(Categorie c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
        }


        public void Delete(Categorie c)
        {
            Categorie c1 = context.Categories.Find(c.CategorieId);
            if (c1 != null)
            {
                context.Categories.Remove(c1);
                context.SaveChanges();
            }
        }

        public void Edit(Categorie newcategorie)
        {
            Categorie oldcategorie = context.Categories.Find(newcategorie.CategorieId);
            if (oldcategorie != null)
            {
                oldcategorie.CategorieName = newcategorie.CategorieName;

                context.SaveChanges();
            }
        }

        public IList<Categorie> GetAll()
        {
            return context.Categories.OrderBy(x => x.CategorieName).ToList();
        }

        public Categorie GetById(int id)
        {
            return context.Categories.Where(x => x.CategorieId == id).SingleOrDefault();
        }
        public int CertificationsCount(int categorieId)
        {
            return context.Categories.Where(s => s.CategorieId == categorieId).Count();
        }
    }
}
