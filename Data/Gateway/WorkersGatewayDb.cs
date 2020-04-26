using System.Collections.Generic;
using System.Linq;
using Domain.Gateway;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Gateway {
    public class WorkersGatewayDb: IWorkersGateway {
        private readonly ZooDbContext _context;

        public WorkersGatewayDb(ZooDbContext context) {
            _context = context;
        }
        
        public List<Worker> GetInZoo(long zooId) {
            return _context.Set<Zoo>()
                .Include(it => it.Workers)
                .FirstOrDefaultAsync(it => it.Id == zooId)
                .Result.Workers.ToList();
        }

        public long AddInZoo(Worker worker, long zooId) {
            var zoo = _context.Set<Zoo>()
                .Include(it => it.Workers)
                .FirstOrDefaultAsync(it => it.Id == zooId).Result;

            var lastId = zoo.Animals.Last().Id;
            worker.Id = lastId + 1;
            
            zoo.Workers.Add(worker);
            _context.Entry(zoo).State = EntityState.Modified;
            
            _context.SaveChanges();
            return worker.Id;
        }
    }
}