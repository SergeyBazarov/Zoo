using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {

    public interface IAddZooInteractor {
        public long Execute(string city);
    }
    
    public class AddZooInteractor : IAddZooInteractor {
        private readonly IZooGateway _gateway;
        public AddZooInteractor(IZooGateway gateway) {
            _gateway = gateway;
        }

        public long Execute(string city) {
            return _gateway.AddZoo(city);
        }
    }
}