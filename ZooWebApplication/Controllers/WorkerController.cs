using System.Collections.Generic;
using Domain.Interactor;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogisticWebApplication.Controllers {
    
    [ApiController]
    [Route("/workers")]
    public class WorkerController : ControllerBase {

        private readonly ILogger<ZooController> _logger;
        private readonly IAddWorkerInZooInteractor _addWorker;
        private readonly ILoadWorkersInZooInteractor _loadWorkers;
        
        public WorkerController(ILogger<ZooController> logger, IAddWorkerInZooInteractor addWorker, ILoadWorkersInZooInteractor loadWorkers) {
            _logger = logger;
            _addWorker = addWorker;
            _loadWorkers = loadWorkers;
        }

        [HttpGet]
        [Route("{zooId}")]
        public IEnumerable<Worker> Get(int zooId) {
            return _loadWorkers.Execute(zooId);
        }

        [HttpPut]
        [Route("{zooId}")]
        public long Put(long zooId, Worker product) {
            return _addWorker.Execute(product, zooId);
        }
    }
}