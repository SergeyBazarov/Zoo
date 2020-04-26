using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {

    public interface ILoadZooInteractor {
        public IEnumerable<Zoo> Execute();
    }
    
    public class LoadZooInteractor : ILoadZooInteractor {
        private readonly IZooGateway _gateway;

        public LoadZooInteractor(IZooGateway gateway) {
            _gateway = gateway;
        }

        public IEnumerable<Zoo> Execute() {
            return _gateway.GetAll();
        }
    }
}