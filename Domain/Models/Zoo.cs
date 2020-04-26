using System.Collections.Generic;

namespace Domain.Models {
    public class Zoo {
        public long Id { set; get; }

        public string City;
        
        public HashSet<Animal> Animals { set; get; }
        
        public HashSet<Worker> Workers { set; get; }
    }
}