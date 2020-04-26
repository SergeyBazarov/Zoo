using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class AddWorkerInZooInteractorTest {
        private readonly Mock<IWorkersGateway> _gateway = new Mock<IWorkersGateway>();

        public AddWorkerInZooInteractorTest() {
            _gateway
                .Setup(it => it.AddInZoo(It.IsAny<Worker>(), 0))
                .Returns(100);
        }


        [Fact]
        public void IdEqualsResult() {
            var interactor = new AddWorkerInZooInteractor(_gateway.Object);
            var worker = new Worker() {Id = 100, Salary = 100.0};
            var result = interactor.Execute(worker, 0);
            Assert.Equal(result, worker.Id);
        }
    }
}