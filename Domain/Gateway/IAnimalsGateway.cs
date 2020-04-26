using System.Collections.Generic;
using Domain.Models;

namespace Domain.Gateway {
    public interface IAnimalsGateway {
        List<Animal> GetInZoo(long zooId);

        long AddInZoo(Animal animal, long zooId);
    }
}