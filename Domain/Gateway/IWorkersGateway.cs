using System.Collections.Generic;
using Domain.Models;

namespace Domain.Gateway {
    public interface IWorkersGateway {
        List<Worker> GetInZoo(long zooId);

        long AddInZoo(Worker worker, long zooId);
    }
}