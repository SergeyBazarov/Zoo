using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {
    public interface ILoadAnimalsInZooInteractor {
        public IEnumerable<Animal> Execute(long zooId);
    }
    
    public class LoadAnimalsInZooInteractor : ILoadAnimalsInZooInteractor {
        private readonly IAnimalsGateway _gateway;

        public LoadAnimalsInZooInteractor(IAnimalsGateway gateway) {
            _gateway = gateway;
        }

        public IEnumerable<Animal> Execute(long zooId) {
            return _gateway.GetInZoo(zooId);
        }
    }
}