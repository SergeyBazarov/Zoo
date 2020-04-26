using System.Collections.Generic;
using Domain.Models;

namespace Data.Entity {
    public class ZooEntity {
        public long Id { get; set; }
        
        public string City { get; set; }

        public List<Worker> Workers { get; set; }

        public List<Animal> Animals { get; set; }
    }
}