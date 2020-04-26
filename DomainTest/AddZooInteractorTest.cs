using System;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class AddZooInteractorTest {
        private readonly Mock<IZooGateway> _gateway = new Mock<IZooGateway>();

        public AddZooInteractorTest() {
            _gateway
                .Setup(it => it.AddZoo(It.IsAny<String>()))
                .Returns(10);
        }


        [Fact]
        public void IdEqualsResult() {
            var interactor = new AddZooInteractor(_gateway.Object);
            var result = interactor.Execute("city");
            var id = 10;
            Assert.Equal(result, id);
        }
    }
}