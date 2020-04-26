using System;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Gateway {
    public interface IZooGateway {
        List<Zoo> GetAll();
        long AddZoo(string city);
    }
}