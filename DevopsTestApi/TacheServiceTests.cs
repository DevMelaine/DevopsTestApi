using DevopsTest.Models;
using DevopsTest.Services;

namespace DevopsTestApi
{
    public class TacheServiceTests
    {
        private readonly TacheService _service;

        public TacheServiceTests()
        {
            _service = new TacheService();
        }

        [Fact]
        public void Add_ShouldAddTache()
        {
            var tache = new Tache { Nom = "Test tâche", IsComplete = false };
            var added = _service.Add(tache);

            Assert.NotNull(added);
            Assert.Equal(1, added.Id);
            Assert.Single(_service.GetAll());
        }

        [Fact]
        public void Get_ShouldReturnTacheById()
        {
            var tache = new Tache { Nom = "Test tâche", IsComplete = false };
            var added = _service.Add(tache);

            var result = _service.Get(added.Id);
            Assert.NotNull(result);
            Assert.Equal("Test tâche", result?.Nom);
        }

        [Fact]
        public void Remove_ShouldDeleteTache()
        {
            var tache = new Tache { Nom = "Tâche à supprimer", IsComplete = false };
            var added = _service.Add(tache);

            _service.Remove(added.Id);

            Assert.Empty(_service.GetAll());
        }
    }
}
