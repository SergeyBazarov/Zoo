using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {
    public interface IAddAnimalInZooInteractor {
        public long Execute(Animal animal, long zooId);
    }
    
    public class AddAnimalInZooInteractor : IAddAnimalInZooInteractor {
        private readonly IAnimalsGateway _gateway;
        
        public AddAnimalInZooInteractor(IAnimalsGateway gateway) {
            _gateway = gateway;
        }

        public long Execute(Animal animal, long zooId) {
            return _gateway.AddInZoo(animal, zooId);
        }
    }
}