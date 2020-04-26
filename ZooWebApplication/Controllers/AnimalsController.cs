using System.Collections.Generic;
using Data.Gateway;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogisticWebApplication.Controllers {
    [ApiController]
    [Route("/animals")]
    public class AnimalsController : ControllerBase {
        
        private readonly ILogger<ZooController> _logger;
        private readonly IAddAnimalInZooInteractor _addAnimal;
        private readonly ILoadAnimalsInZooInteractor _loadAnimals;

        public AnimalsController(ILogger<ZooController> logger, IAddAnimalInZooInteractor addAnimal, ILoadAnimalsInZooInteractor loadAnimals) {
            _logger = logger;
            _addAnimal = addAnimal;
            _loadAnimals = loadAnimals;
        }

        [HttpGet]
        [Route("{zooId}")]
        public IEnumerable<Animal> Get(int zooId) {
            return _loadAnimals.Execute(zooId);
        }

        [HttpPut]
        [Route("{zooId}")]
        public long Put(long zooId, Animal animal) {
            return _addAnimal.Execute(animal, zooId);
        }
    }
}