using System.Collections.Generic;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class LoadAnimalsInZooInteractorTest {
        private readonly Mock<IAnimalsGateway> _emptyGateway = new Mock<IAnimalsGateway>();

        private readonly List<Animal> _list = new List<Animal> {
            new Animal {Id = 0, IsPredator = true},
            new Animal {Id = 1, IsPredator = true},
        };

        private readonly Mock<IAnimalsGateway> _listGateway = new Mock<IAnimalsGateway>();


        public LoadAnimalsInZooInteractorTest() {
            _emptyGateway
                .Setup(it => it.GetInZoo(0))
                .Returns(new List<Animal>());

            _listGateway
                .Setup(it => it.GetInZoo(1))
                .Returns(_list);
        }


        [Fact]
        public void EmptyResult() {
            var interactor = new LoadAnimalsInZooInteractor(_emptyGateway.Object);
            var result = interactor.Execute(0);
            Assert.Empty(result);
        }

        [Fact]
        public void ListResult() {
            var interactor = new LoadAnimalsInZooInteractor(_listGateway.Object);
            var result = interactor.Execute(1);
            Assert.Equal(_list, result);
        }
    }
}