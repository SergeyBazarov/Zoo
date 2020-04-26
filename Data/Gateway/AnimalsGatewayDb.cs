using System.Collections.Generic;
using System.Linq;
using Domain.Gateway;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Gateway {
    public class AnimalsGatewayDb : IAnimalsGateway {
        private readonly ZooDbContext _context;

        public AnimalsGatewayDb(ZooDbContext context) {
            _context = context;
        }
        
        public List<Animal> GetInZoo(long zooId) {
            return _context.Set<Zoo>()
                .Include(it => it.Animals)
                .FirstOrDefaultAsync(it => it.Id == zooId)
                .Result.Animals.ToList();
        }

        public long AddInZoo(Animal animal, long zooId) {
            var zoo = _context.Set<Zoo>()
                .Include(it => it.Animals)
                .FirstOrDefaultAsync(it => it.Id == zooId).Result;

            var lastId = zoo.Animals.Last().Id;
            animal.Id = lastId + 1;
            
            zoo.Animals.Add(animal);
            _context.Entry(zoo).State = EntityState.Modified;
            
            _context.SaveChanges();
            return animal.Id;
        }
    }
}