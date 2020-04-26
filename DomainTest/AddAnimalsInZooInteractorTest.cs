using System.Collections.Generic;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class AddAnimalsInZooInteractorTest {
        private readonly Mock<IAnimalsGateway> _gateway = new Mock<IAnimalsGateway>();

        public AddAnimalsInZooInteractorTest() {
            _gateway
                .Setup(it => it.AddInZoo(It.IsAny<Animal>(), 0))
                .Returns(100);
        }


        [Fact]
        public void IdEqualsResult() {
            var interactor = new AddAnimalInZooInteractor(_gateway.Object);
            var animal = new Animal {Id = 100, IsPredator = false};
            var result = interactor.Execute(animal, 0);
            Assert.Equal(result, animal.Id);
        }
    }
}