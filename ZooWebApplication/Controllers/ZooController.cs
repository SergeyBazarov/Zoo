using System;
using System.Collections.Generic;
using Domain.Interactor;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogisticWebApplication.Controllers {
    
    [ApiController]
    [Route("/zoo")]
    public class ZooController : ControllerBase {

        private readonly ILogger<ZooController> _logger;
        private readonly IAddZooInteractor _addZoo;
        private readonly ILoadZooInteractor _loadZoo;

        public ZooController(ILogger<ZooController> logger, IAddZooInteractor addZoo, ILoadZooInteractor loadZoo) {
            _logger = logger;
            _addZoo = addZoo;
            _loadZoo = loadZoo;
        }

        [HttpGet]
        public IEnumerable<Zoo> Get() {
            return _loadZoo.Execute();
        }
        
        [HttpPut]
        public long Put(string city) {
            return _addZoo.Execute(city);
        }
        
    }
}