using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {
    public interface ILoadWorkersInZooInteractor {
        public IEnumerable<Worker> Execute(long zooId);
    }

    public class LoadWorkersInZooInteractor : ILoadWorkersInZooInteractor {
        private readonly IWorkersGateway _gateway;

        public LoadWorkersInZooInteractor(IWorkersGateway gateway) {
            _gateway = gateway;
        }

        public IEnumerable<Worker> Execute(long zooId) {
            return _gateway.GetInZoo(zooId);
        }
    }
}