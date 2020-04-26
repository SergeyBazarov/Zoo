using System.Collections.Generic;
using System.Linq;
using Domain.Gateway;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Gateway {
    
    public class ZooGatewayDb : IZooGateway {
        private readonly ZooDbContext _context;

        public ZooGatewayDb(ZooDbContext context) {
            _context = context;
        }

        public List<Zoo> GetAll() {
            return _context.Set<Zoo>()
                .Include(it => it.Animals)
                .Include(it => it.Workers)
                .ToList();
        }

        public long AddZoo(string city) {
            var zoos = _context.Set<Zoo>();

            var lastId = zoos.Last().Id;

            var newZoo = new Zoo {
                Id = lastId,
                City = city
            };
        
            zoos.Add(newZoo);
            _context.Entry(newZoo).State = EntityState.Modified;
        
            _context.SaveChanges();
            return lastId;
        }
    }
}