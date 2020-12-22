using System.Collections.Generic;

namespace ProjectStore.Models.Repositories
{
    public interface ICertificationRepository
    {
        IList<Certification> GetAll();
        Certification GetById(int id);
        void Add(Certification c);
        Certification Edit(Certification c);
        void Delete(Certification c);
        IList<Certification> GetCertificationsByCategorieID(int? categorieId);
        IList<Certification> FindByName(string name);
    }
}
