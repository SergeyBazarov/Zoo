using System.Collections.Generic;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class LoadZooInteractorTest {
        private readonly Mock<IZooGateway> _emptyGateway = new Mock<IZooGateway>();

        private readonly List<Zoo> _list = new List<Zoo> {
            new Zoo {City = "city1"},
            new Zoo {City = "city2"},
        };

        private readonly Mock<IZooGateway> _listGateway = new Mock<IZooGateway>();


        public LoadZooInteractorTest() {
            _emptyGateway
                .Setup(it => it.GetAll())
                .Returns(new List<Zoo>());

            _listGateway
                .Setup(it => it.GetAll())
                .Returns(_list);
        }


        [Fact]
        public void EmptyResult() {
            var interactor = new LoadZooInteractor(_emptyGateway.Object);
            var result = interactor.Execute();
            Assert.Empty(result);
        }

        [Fact]
        public void ListResult() {
            var interactor = new LoadZooInteractor(_listGateway.Object);
            var result = interactor.Execute();
            Assert.Equal(_list, result);
        }
    }
}