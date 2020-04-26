using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {

    public interface IAddWorkerInZooInteractor {
        public long Execute(Worker worker, long zooId);
    }
    
    public class AddWorkerInZooInteractor : IAddWorkerInZooInteractor{
        private readonly IWorkersGateway _gateway;
        
        public AddWorkerInZooInteractor(IWorkersGateway gateway) {
            _gateway = gateway;
        }

        public long Execute(Worker worker, long zooId) {
            return _gateway.AddInZoo(worker, zooId);
        }
    }
}