using DevopsTest.Controllers;
using DevopsTest.Models;
using DevopsTest.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DevopsTestApi
{
    public class TachesControllerTests
    {
        private readonly TachesController _controller;
        private readonly TacheService _service;

        public TachesControllerTests()
        {
            _service = new TacheService();
            _controller = new TachesController(_service);
        }

        [Fact]
        public void GetAll_ReturnsEmptyListInitially()
        {
            var result = _controller.GetAll().Value;
            Assert.Empty(result);
        }

        [Fact]
        public void Create_ShouldReturnCreatedTache()
        {
            var tache = new Tache { Nom = "Nouvelle tâche", IsComplete = false };
            var result = _controller.Create(tache).Result as CreatedAtActionResult;

            Assert.NotNull(result);
            var createdTache = result.Value as Tache;
            Assert.NotNull(createdTache);
            Assert.Equal("Nouvelle tâche", createdTache?.Nom);
        }

        [Fact]
        public void Delete_ShouldRemoveTache()
        {
            var tache = _service.Add(new Tache { Nom = "Tâche à supprimer" });
            var result = _controller.Delete(tache.Id) as NoContentResult;

            Assert.NotNull(result);
            Assert.Empty(_service.GetAll());
        }
    }
}
