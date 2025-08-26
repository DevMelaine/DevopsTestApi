using DevopsTest.Models;
using System.Xml.Linq;

namespace DevopsTest.Services
{
    public class TacheService
    {
        private readonly List<Tache> _taches = [];

        public List<Tache> GetAll() => _taches;

        public Tache? Get(int id) => _taches.FirstOrDefault(t => t.Id == id);

        public Tache Add(Tache tache)
        {
            tache.Id = _taches.Count + 1;
            _taches.Add(tache);
            return tache;
        }

        public void Remove(int id)
        {
            var tache = Get(id);
            if (tache != null) _taches.Remove(tache);
        }
    }
}
