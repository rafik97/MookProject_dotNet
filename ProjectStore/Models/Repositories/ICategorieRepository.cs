using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.Models.Repositories
{
    public interface ICategorieRepository
    {
        IList<Categorie> GetAll();
        Categorie GetById(int id);
        void Add(Categorie c);
        void Edit(Categorie c);
        void Delete(Categorie c);
        int CertificationsCount(int categorieId);
    }
}
